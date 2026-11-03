# Program Organization - C#

As a C# application grows, you need to organize the code. .NET provides a hierarchy of organizational tools—solutions, projects, assemblies, namespaces, and types—that work together to keep large codebases manageable. The conventions described here represent broad consensus in the .NET community.

---

## The Organizational Hierarchy

Organize a typical .NET application in layers, from broadest to most specific:

| Level | Description | Example |
| :--- | :--- | :--- |
| **Solution** | A container that groups related projects. | `MyApp.sln` / `MyApp.slnx` |
| **Project** | A build unit that produces one assembly. | `MyApp.Web.csproj` |
| **Assembly** | The `.dll` or `.exe` produced by a project. | `MyApp.Web.dll` |
| **Namespace** | A logical grouping of types. | `MyApp.Web.Controllers` |
| **Type** | A class, struct, interface, enum, or record. | `OrderController` |

Each level serves a different purpose:

* **Solutions** organize your development workflow.
* **Projects** define what gets compiled together, and each project produces one assembly.
* **Assemblies** are the unit of deployment and versioning.
* **Namespaces** prevent naming collisions and make types easy to find. A single assembly can contain multiple namespaces, and a single namespace can span multiple assemblies.
* **Types** define the actual behavior and data.

---

## Projects and Assemblies

Each project compiles into a single assembly: a class library or executable. Start with a single project for small applications—don't split prematurely. The primary reason to create a separate project is to reuse that code in more than one application.

Beyond reuse, add projects when you have a concrete reason:

* **Share code across applications:** Extract shared logic into a class library that multiple apps reference.
* **Separate concerns:** Keep your data access, business logic, and presentation layers independent.
* **Control dependencies:** A project can only use types from projects it explicitly references.

---

## Match Namespaces to Folder Structure

Keep your folder structure and namespace hierarchy identical. If a class is located in `Services/Payment/`, its namespace should be `MyApp.Services.Payment`.

```text
MyApp/
├── Services/
│   └── Payment/
│       └── CreditCardProcessor.cs  --> namespace MyApp.Services.Payment
```

Your root namespace is automatically set to the name of your project file. Types in subfolders don't automatically get sub-namespaces—you declare the namespace explicitly in each file—but always keep them in sync.

> **Tip:** You can change the root namespace by setting `<RootNamespace>` in your project file (`.csproj`):
> ```xml
> <PropertyGroup>
>   <RootNamespace>MyCompany.MyApp</RootNamespace>
> <PropertyGroup>
> ```

---

## Organize Namespaces by Feature, Not by Type Kind

Group related types into namespaces by feature or responsibility. Place an interface, its implementations, and supporting types together:

```csharp
// Good: Group by feature
namespace MyApp.Payments;

public interface IPaymentProcessor
{
    bool ProcessPayment(decimal amount);
}

public class CreditCardProcessor : IPaymentProcessor
{
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processed {amount:C}");
        return true;
    }
}
```

Avoid grouping types purely by their kind (e.g., putting all interfaces in `MyApp.Interfaces` and all classes in `MyApp.Classes`). Feature-based organization keeps everything you need in one place, making the code easier to navigate and reason about.

---

## Access Modifiers and Assemblies

C# access modifiers control access to types and members based on assembly boundaries:

* `public` — Accessible from any assembly that references this assembly.
* `internal` — Accessible only within the same assembly (the default for top-level types).
* `private`, `protected`, `private protected`, `protected internal` — Accessible based on the containing type, the assembly, or derived types.

Mark types as `internal` unless they need to be accessed outside the assembly. This practice hides implementation details and gives you freedom to refactor without breaking consumers.

```csharp
// Expose the interface publicly
public interface IOrderService
{
    void ProcessOrder(int orderId);
}

// Keep the internal implementation hidden inside the assembly
internal class OrderService : IOrderService
{
    public void ProcessOrder(int orderId)
    {
        // Implementation details
    }
}
```

---

## Recommended Practices

1. **Name namespaces consistently:** Use `PascalCase` and match namespace hierarchies to directory structures.
2. **Keep projects focused:** Create a new project only when you need separate deployment, strict dependency control, or code sharing.
3. **Use file-scoped namespaces:** Use `namespace MyApp.Services;` rather than block-scoped `namespace MyApp.Services { ... }` to reduce indentation levels.
4. **Default to `internal`:** Keep top-level types `internal` unless they form part of your assembly's public API.