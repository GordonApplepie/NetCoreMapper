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

#### Annotations

If you do not use any annotations each property will be mapped by names.

Use the MapOn attribute to specify the property names on which will be mapped
```csharp
public class EntityOne {
  
  public string Id { get; set; }
  
  [MapOn("name", "name1")] // This property will be mapped on name and name1 
  public string Name { get; set; }
}
```

Use the NoMap attribute to avoid mapping a property on all or specific destination types
```csharp
public class EntityOne {
  [NoMap()] // No mapping will be applied
  public string Id { get; set; }
  
  [NoMap(typeOf(DestEntity1, DestEntity2))] // No mapping only for DestEntity1 and DestEntity2 
  public string Name { get; set; }
}
```

Use the OnlyMap attribute to specify on which types CoreMapper will map
```csharp
public class EntityOne {
  
  public string Id { get; set; }
  
  [OnlyMap(typeOf(DestEntity1, DestEntity2))] // Mapping only on DestEntity1 and DestEntity2 
  public string Name { get; set; }
}
```
