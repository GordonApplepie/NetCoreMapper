# NetCoreMapper
Use this reflection based object mapper on your net core projects
### Usage

Initialize NetCoreMapper
```csharp
using GordonApplepie.NetCoreMapper;
```

Map one object into a new object
```csharp
var destination = CoreMapper.Map<DestinationType>(source);
```

Map one object into an existing object
```csharp
CoreMapper.Map(destination, source);
```
