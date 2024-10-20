# Manufacturing Inventory Management System

## Descripción

Una empresa de manufactura gestiona productos terminados en su bodega, preparándolos para distribución. Este proceso de inventario implica:


- **Entrada de mercancía.**
- **Salida de mercancía.**
- **Identificación de mercancía defectuosa.**

## Tecnologías Utilizadas

- **Frontend**: Blazor - .NET 8
- **Backend**: .NET 8
- **Base de Datos**: SQL Server 2022

## Arquitectura Utilizada

Clean Architecture

## Clone

git clone https://github.com/jhossedmolina/ManufacturingInventoryManagementSystem.git

## Creación Base De Datos SQL Server

Paso 1: Crear Base De Datos


CREATE DATABASE [ManufacturingInventoryDB]


Paso 2: Usar los Scripts almacenados en la carpeta Scripts SQL

## Instalación del Proyecto Web API

Paso 1: Clonar el repositorio


Paso 3: Restaurar dependencias


Navega a la carpeta del proyecto ManufacturingInventory.API y ejecuta el comando para restaurar los paquetes NuGet:



cd ManufacturingInventory.API


dotnet restore


Paso 4: Configurar la base de datos


Configurar la cadena de conexión en el archivo appsettings.json dentro de la carpeta principal del proyecto


Paso 5: Ejecutar la API 


dotnet run

https://localhost:7097/swagger/index.html

## Instalación del Proyecto Blazor

Paso 1: Restaurar dependencias


Navega a la carpeta del proyecto ManufacturingInventory.WebAssembly y ejecuta el comando para restaurar los paquetes NuGet:


cd ManufacturingInventory.WebAssembly


dotnet restore

Paso 2: Ejecutar el Proyecto Blazor


dotnet run

## Documentación de Endpoints

A continuación se presentan los endpoints disponibles en la API:

### 1. Registro

**Endpoint**: api/User/Register


**Descripción**: Registra un nuevo usuario para ser utilizado en la aplicación

### 2. Login

**Endpoint**: api/User/Login


**Descripción**: Se utiliza para autenticarse y obtener el Token JWT. Debe ingresar un correo electronico y una contraseña creados previamente en el endpoint de Registro

### 3. Obtener Todos los Productos

**Endpoint**: api/Product/GetAllProducts


**Descripción**: Obtiene la lista de todos los productos existentes en la base de datos.

### 4. Obtener Productos por Estado

**Endpoint**: api/Product/GetProductsByStatus/{status}


**Descripción**: Obtiene una lista de productos filtrados por su estado.


**Parámetros**:


**status**: Puede ser uno de los siguientes:


- **En Stock**
- **Defectuoso**
- **Fuera De Stock**

### 5. Obtener Producto por ID

**Endpoint**: api/Product/GetProductById/{id}


**Descripción**: Obtiene un producto específico por su ID.

### 6. Agregar un Nuevo Producto

**Endpoint**: api/Product/AddProduct


**Descripción**: Agrega un nuevo producto a la base de datos.

**Enumeraciones**:


**ProductionType**:


- **1 = Elaborado A Mano**
- **2 = Elaborado A Mano Y Máquina**


**Status**:


- **1 = En Stock**
- **2 = Defectuoso**
- **3 = Fuera De Stock**

### 7. Marcar Producto como Defectuoso

**Endpoint**: api/Product/MarkProductAsDefective


**Descripción**: Recibe como parámetro el ID de un producto y actualiza su estado a defectuoso.

### 8. Actualizar Información del Producto

**Endpoint**: api/Product/UpdateProduct


**Descripción**: Recibe como parámetro el ID de un producto y actualiza su información (nombre del producto, tipo de elaboración, estado del producto).


**Enumeraciones**:


**ProductionType**:


- **1 = Elaborado A Mano**
- **2 = Elaborado A Mano Y Máquina**


**Status**:


- **1 = En Stock**
- **2 = Defectuoso**
- **3 = Fuera De Stock**

### 9. Eliminar Producto

**Endpoint**: api/Product/DeleteProduct/{id}


**Descripción**: Recibe como parámetro el ID de un producto y elimina el producto correspondiente.