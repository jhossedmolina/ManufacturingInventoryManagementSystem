# Manufacturing Inventory Management System

## Descripción

Una empresa de manufactura gestiona productos terminados en su bodega, preparándolos para distribución. Este proceso de inventario implica:
• Entrada de mercancía.
• Salida de mercancía.
• Identificación de mercancía defectuosa.

## Tecnologías Utilizadas

- **Frontend**: Blazor - .NET 8
- **Backend**: .NET 8
- **Base de Datos**: SQL Server 2022

## Clone

git clone https://github.com/jhossedmolina/ManufacturingInventoryManagementSystem.git

## Documentación de Endpoints
A continuación se presentan los endpoints disponibles en la API:

### 1. Obtener Todos los Productos
- **Endpoint**: api/Product/GetAllProducts
- **Descripción**: Obtiene la lista de todos los productos existentes en la base de datos.
### 2. Obtener Productos por Estado
- **Endpoint: api/Product/GetProductsByStatus/{status}
- **Descripción: Obtiene una lista de productos filtrados por su estado.
- **Parámetros:
**status**: Puede ser uno de los siguientes:
- En Stock
- Defectuoso
- Fuera De Stock
### 3. Obtener Producto por ID
- **Endpoint**: api/Product/GetProductById/{id}
**Descripción**: Obtiene un producto específico por su ID.
### 4. Agregar un Nuevo Producto
Endpoint: api/Product/AddProduct
Descripción: Agrega un nuevo producto a la base de datos.
Enumeraciones:
ProductionType:
Elaborado A Mano = 1
Elaborado A Mano Y Máquina = 2
Status:
En Stock = 1
Defectuoso = 2
Fuera De Stock = 3
### 5. Marcar Producto como Defectuoso
Endpoint: api/Product/MarkProductAsDefective
Descripción: Recibe como parámetro el ID de un producto y actualiza su estado a defectuoso.
### 6. Actualizar Información del Producto
Endpoint: api/Product/UpdateProduct
Descripción: Recibe como parámetro el ID de un producto y actualiza su información (nombre del producto, tipo de elaboración, estado del producto).
### 7. Eliminar Producto
Endpoint: api/Product/DeleteProduct/{id}
Descripción: Recibe como parámetro el ID de un producto y elimina el producto correspondiente.