import asyncio
import tcpStream
import json
from ProgramHandler import ProgramHandler 
import KeyPressHandler
from evdev.ecodes import *
import evdev
class main():
    def __init__(self):
        self.tcp = tcpStream.tcpServer("10000")
        self.loop = asyncio.get_event_loop()
        self.loop.create_task(self._main())
        self.loop.run_forever()

    async def _main(self):
        await self.tcp.readerCallBackAdder(self.remoteCommandExecute)
        await self.tcp.readerCallBackAdder(self.remoteKeystrokeExecute)


    async def remoteCommandExecute(self,data):
        data = json.loads(data)
        if data[0] == "SendCommand":
            ProgramHandler(data[1])

    async def remoteKeystrokeExecute(self,data):
        data = json.loads(data)
        if data[0] == "SendKey":
            print(data)
            keys = [data[2]]
            for i in data[1]:
                keys.append(i)
            keys.reverse()
            print(keys)
            key = KeyPressHandler.KeyPress(keys=keys)
            await key.keyPress(keyState=KeyPressHandler.KEY_STATE.KEY_TOGGLE,pressDuration=0.1)



main()