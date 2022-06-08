# Cheat sheet
 
## AutoFixture
### Create Fixture
 ```csharp
// create fixture
var fixture = new Fixture();

// create model
var model = fixture.Create<Level4Model>();
 ```

### Customize Fixture
```csharp
// change only for this creation
var person = fixture.Build<Person>()
    .With(x => x.Age, 28)
    .Create();
 
 // change for all calls
 fixture.Customize<Person>(c => c.With(x => x.FirstName, "Paul"));
 var person = fixture.Create<Person>();
 
 // omit values (setting null value)
 var model = fixture.Build<TestModel>()
    .Without(e => e.Test)
    .Create();
```
### Freeze
```csharp
var fixture = new Fixture();
// freeze strings with "Name"
var expectedName = fixture.Freeze("Name");
...
```

### AutoData
```csharp
// Creates a fixture of Myclass automatically
[Theory, AutoData]
public void Test_WithAutoData(Myclass myClass)
```

## Moq
### Create Mock
 ```csharp
// create and get mock (for setup)
var mock = new Mock<IFoo>();

// Create and get object
var object = Mock.Of<Object>();
 ```

### Setup
```csharp
mock.Setup(foo => foo.DoSomething("ping")).Returns(true);

// use parameter in return value
mock.Setup(x => x.DoSomethingStringy(It.IsAny<string>())).Returns((string s) => s.ToLower());
```

### Argument matcher
```csharp
// any value
mock.Setup(foo => foo.DoSomething(It.IsAny<string>())).Returns(true);

// matching Func<int>, lazy evaluated
mock.Setup(foo => foo.Add(It.Is<int>(i => i % 2 == 0).Returns(true);

// matching ranges
mock.Setup(foo => foo.Add(It.IsInRange<int>(0, 10, Range.Inclusive))).Returns(true);

// matching regex
mock.Setup(x => x.DoSomethingStringy(It.IsRegex("[a-d]+", RegexOptions.IgnoreCase))).Returns("foo");
```

### Throwing exceptions
```csharp
// Throw InvaldOperationException with parameter "reset"
mock.Setup(foo => foo.DoSomething("reset").Throws<InvalidOperationException>();

// Throw ArgumentException if parameter is empty
mock.Setup(foo => foo.DoSomething("").Throws(new ArgumentException("command"));
```

### Async functions
```csharp
mock.Setup(foo => foo.DoSomethingAsync()).ReturnsAsync(true);

// Mocking DbSet without IAsyncEnumerable with Moq.EntityFrameworkCore
var entity = new MODEL;
mock.Setup(foo => foo.Set<MODEL>()).ReturnsDbSet(new[] { entity });

// Mocking Queryables with ToListAsync, etc. with MockQueryable.Moq
var users = new List<UserEntity> 
{
    new UserEntity { Id = userId, ...}
  ... etc. 
};

var mock = users.AsQueryable().BuildMock();

_dbContextMock.Setup(ctx => ctx.SetQueryable<UserEntity>()).Returns(mock.Object);
```

### Verify Mocks
```csharp
// called once
mock.Verify(foo => foo.DoSomething("ping"));

// Verify with custom error message for failure
mock.Verify(foo => foo.DoSomething("ping"), "When doing operation X, the service should be pinged always");

// Method should never be called
mock.Verify(foo => foo.DoSomething("ping"), Times.Never());
```

### AutoMoqData
```csharp
// Custom attribute for AutoMoq
public class AutoMoqDataAttribute : AutoDataAttribute
{
    public AutoMoqDataAttribute()
        : base(new Fixture()
            .Customize(new AutoMoqCustomization()))
    {
    }
}
```

### Frozen
```csharp
// Freeze object in test parameters
[Theory, AutoMoqData]
public void Test_WithAutoData([Frozen]Mock<IService> serviceMock)
```
