# TBD

## Adding Contoller
1. Create the controller class with the general skeleton code
```
[ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        //Can be reached with 'example/'
        public void Get(){
            //Do Stuff
        }
        
        [HttpGet("namedMethod")]
        //Can be reached with 'example/namedMethod'
        public void Get(){
            //Do Stuff
        }
    }
```
2. Update proxy.config.js
```
...
const PROXY_CONFIG = [
  {
  //ADD THE CONTROLLER NAME TO 'CONTEXT' 
    context: [
      ...
      "/example",
      ...
   ],
    ...
  }
]
...
```