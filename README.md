# LessToCss


LessToCss is a console prompt application multiplatform for compile less files using Microsoft NodeServices interface.

  


### Build and Publish

Execute dotnet restore for restore the required nuggets


For windows environments...

```sh
$ dotnet publish -c Release -r win10-x64
```


### Execution
For create a css file:
```sh
$ LestToCss -n lessfile.less -o cssfile.css 
```
or 
Only prompt output :
```sh
$ LestToCss -n lessfile.less
```
