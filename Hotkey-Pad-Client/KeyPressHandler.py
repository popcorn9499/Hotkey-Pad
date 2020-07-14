import asyncio
import evdev

class KEY_STATE: #Keep track of all the different key states a key can be in
    KEY_DOWN = 1
    KEY_UP = 0
    KEY_HOLD = 2
    KEY_TOGGLE = 3 #toggle the key. Unofficial keystate to toggle the key

ECODES = evdev.ecodes #keyboard ecodes
UINPUT = evdev.UInput() #create a keyboard device

class Key(): #Manage all the things required for UInput to press keys
    def __init__(self):
        pass

    async def addKey(self,keyCode,keyState): #handles adding keys to the event queue
        UINPUT.write(ECODES.EV_KEY,keyCode,keyState)

    async def sync(self): #syncronizes the key events sent
        UINPUT.syn()


class KeyPress(Key): #Keypress handler. handling multiple key strokes.
    def __init__(self, keys = []):
        self.keys = keys
        super()

    async def _pressHandler(self,keyState): #handles pressing the key strokes
        for key in self.keys: #press the required keys
            await self.addKey(key,keyState)
    
    async def keyPress(self,keyState=KEY_STATE.KEY_TOGGLE,pressDuration=0): #handles taking in the keystroke depending if its a toggle or a set duration
        if keyState == KEY_STATE.KEY_TOGGLE:
            await self._pressHandler(KEY_STATE.KEY_DOWN)
            await asyncio.sleep(pressDuration)
            await self.sync()
            await asyncio.sleep(pressDuration)
            await self._pressHandler(KEY_STATE.KEY_UP)
            await self.sync()
        else:
            await self._pressHandler(keyState)
            await asyncio.sleep(pressDuration)
            await self.sync()
