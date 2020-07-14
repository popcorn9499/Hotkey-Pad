import asyncio

class ProgramHandler(): #manage programs being launched by a hotkey
    def __init__(self,cmd): #create the object and start the async task
        self.cmd = cmd
        loop = asyncio.get_event_loop()
        loop.create_task(self.run())

    async def run(self): #executes the program
        proc = await asyncio.create_subprocess_shell(
        self.cmd,
        stdout=asyncio.subprocess.PIPE,
        stderr=asyncio.subprocess.PIPE)

        stdout, stderr = await proc.communicate() #handles initializing the standard output and error output
        if stdout:
            print(f'[stdout]\n{stdout.decode()}')
        if stderr:
            print(f'[stderr]\n{stderr.decode()}')