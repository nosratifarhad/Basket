# 🛒 Basket Service

## 📌 Introduction
The **Basket Service** is a microservice for managing shopping baskets in an e-commerce application. It provides APIs for adding, removing, and updating items in a user's basket.

## 🚀 Getting Started

### 📋 Prerequisites
- .NET 8
- SQL Server (or an alternative database)
- RabbitMQ (if event-driven architecture is used)

### 🔧 Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/nosratifarhad/Basket.git
   cd basket-service
   ```
2. Install dependencies:
   ```sh
   dotnet restore
   ```
3. Run the application:
   ```sh
   dotnet run
   ```

## 🛠 Technologies Used
- **ASP.NET Core 8** - Web API framework
- **MediatR** - CQRS pattern implementation
- **Dapper** - Data access
- **Repository Pattern** - Separation of concerns
- **MassTransit** - Message-based event-driven architecture

## 📖 API Endpoints

### ➕ Add Item to Basket
```http
POST /api/v1/baskets
```
#### Request Body
```json
{
  "userId": 123,
  "slug": "product-xyz",
  "price": 50000,
  "productName": "Product XYZ"
}
```
#### Response
**201 Created**

---

### ❌ Remove Basket
```http
DELETE /api/v1/baskets
```
#### Response
**204 NoContent**

---

### 🔽 Decrease Item Quantity
```http
PUT /api/v1/baskets/{userBasketItemId}/decrease
```
#### Response
**204 NoContent**

---

### 🔼 Increase Item Quantity
```http
PUT /api/v1/baskets/{userBasketItemId}/increase
```
#### Response
**204 NoContent**

## 📄 Code Structure

### `BasketService`
Handles basket operations including adding/removing items and updating quantities.

### `UserBasketBuilder`
Responsible for building basket objects and calculating VAT.

### `Repositories`
- `IBasketReadRepository` - Read operations
- `IBasketWriteRepository` - Write operations

### `ChangedPriceConsumer`
Handles price change events using **MassTransit**. Updates basket items and recalculates total amounts when a price change event occurs.

#### **Key Method: `Consume`**
- Fetches all basket items related to the changed price.
- Updates the price, sets `UserChangedSeen` to `false`.
- Updates affected baskets by recalculating VAT and total amount.

## 🤝 Contributing
Feel free to contribute by submitting a pull request.

## 📜 License
MIT License.

