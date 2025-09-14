ASP.NET Core GraphQL API for managing customers, products and orders with PostgreSQL via Entity Framework Core and HotChocolate.

Key points
- Target: .NET 9 (net9.0)
- GraphQL server: HotChocolate (queries, mutations, subscriptions)
- Data access: Entity Framework Core with Npgsql (PostgreSQL)
- Development subscription provider: in-memory subscriptions (replace for production)
- Project packages (selected): HotChocolate.AspNetCore, HotChocolate.Data, Microsoft.EntityFrameworkCore, Npgsql.EntityFrameworkCore.PostgreSQL

Contents
- GraphQL endpoint: /graphql
- Database context: GraphQlDbContext (Customers, Products, Orders, OrderItems)
- Query operations: GetCustomers, GetProducts, GetOrders, GetOrderItems (support projection, filtering and sorting)
- Mutation operations: AddCustomer, AddProduct, AddOrder
- Subscriptions: OnCustomerAdded, OnProductAdded, OnOrderCreated

Requirements
- .NET 9 SDK
- PostgreSQL instance (connection string configured in appsettings or user secrets)
- Optional: Docker / Docker Compose for local orchestration

Quick start (local)
1. Configure DB connection (example in appsettings.json or via user secrets):
   - ConnectionStrings:DbConnection = "Host=localhost;Database=orders;Username=...;Password=..."
2. Apply EF Core migrations:
   - Using CLI: dotnet ef database update
   - Or in Visual Studio run migrations from __Package Manager Console__: Add-Migration / Update-Database
3. Run:
   - dotnet run
4. Open GraphQL playground at: http://localhost:5000/graphql (or binding from Kestrel)

Database and models
- Customer: Id, FirstName, LastName, Address, Email, Orders
- Product: Id, Name, Description, Price, QuantityInStock
- Order: Id, CustomerId, CreatedAt, TotalPrice, OrderItems
- OrderItem: composite key (OrderId, ProductId), ProductQuantity

GraphQL schema summary
- Queries
  - GetCustomers(): IQueryable<Customer>
  - GetProducts(): IQueryable<Product>
  - GetOrders(): IQueryable<Order>
  - GetOrderItems(): IQueryable<OrderItem>
  - All queries use HotChocolate's __UseProjection__, __UseFiltering__, __UseSorting__.

- Mutations
  - AddCustomer(customerDto: CustomerInputDto): Customer
    - CustomerInputDto: FirstName, LastName, Address, Email
  - AddProduct(productDto: ProductInputDto): Product
    - ProductInputDto: Name, Description, Price, QuantityInStock
  - AddOrder(customerId: Int!, orderItems: [OrderItemInputDto!]!): Order
    - OrderItemInputDto: ProductId, ProductQuantity
    - AddOrder uses a transaction, checks product stock, decrements QuantityInStock and computes TotalPrice.

- Subscriptions
  - OnCustomerAdded: publishes created Customer
  - OnProductAdded: publishes created Product
  - OnOrderCreated: publishes created Order
  - Note: current implementation publishes full entity instances. Consider publishing minimal event DTOs (avoid leaking sensitive fields such as customer address/email or product descriptions) and applying authorization to subscriptions.
