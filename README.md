# WebMarket - Mini Proyecto Dockerizado

Bienvenido al proyecto WebMarket. Este repositorio incluye un backend en .NET 8, un frontend en Angular y una base de datos SQL Server, todo completamente dockerizado. Ha sido diseñado como una prueba de concepto para demostrar una arquitectura limpia, escalable y con contenedores, ideal para iniciarte en entornos modernos de desarrollo.

---

## 📄 Tabla de Contenidos

1. [Descripción del Proyecto](#descripci%C3%B3n-del-proyecto)
2. [Estructura del Repositorio](#estructura-del-repositorio)
3. [Requisitos Previos](#requisitos-previos)
4. [Clonar el Repositorio](#clonar-el-repositorio)
5. [Levantando los Contenedores](#levantando-los-contenedores)
6. [Accediendo a la Aplicación](#accediendo-a-la-aplicaci%C3%B3n)
7. [Notas Importantes y Solución de Problemas](#notas-importantes-y-soluci%C3%B3n-de-problemas)
8. [Contacto](#contacto)

---

## Descripción del Proyecto

Este mini proyecto representa una tienda ficticia donde puedes añadir, modificar, eliminar y listar productos, agregarlos a un carrito y realizar pedidos. 

### Tecnologías Utilizadas
- 🚀 **Angular 19** para el frontend
- 🚀 **.NET 8 Web API** para el backend
- 🚀 **SQL Server 2022** para persistencia de datos
- 🚀 **Docker & Docker Compose** para orquestación

---

## Estructura del Repositorio

```text
WebMarket-Clean-Architecture/
├── PRG.WebMarket.Backend/        # Solución .NET con los proyectos WebAPI, Dominio, Aplicación, Infraestructura, etc.
├── PRG.WebMarket.Frontend/       # Proyecto Angular 19
├── docker-compose.yml            # Orquestador de servicios
├── README.md                     # Esta guía
```

---

## Requisitos Previos

Antes de comenzar, asegúrate de tener instalado lo siguiente:

- 🐳 (Necesario)[**Docker Desktop**](https://www.docker.com/products/docker-desktop)
- 🧰 (Necesario)[**Git**](https://git-scm.com/)
- 💻 (Opcional) [**Visual Studio Code**](https://code.visualstudio.com/)
- 🧪 (Opcional) [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

---

## Clonar el Repositorio

```bash
git clone https://github.com/P3droRamirez/WebMarket-Clean-Architecture---Mini-Proyecto-Dockerizado.git
cd WebMarket-Clean-Architecture---Mini-Proyecto-Dockerizado
```

---

## Levantando los Contenedores

### Paso 1 – Compilar las imágenes

```bash
docker-compose build
```

### Paso 2 – Arrancar los contenedores

> ⚠️ **IMPORTANTE:** Arranca primero SQL Server para evitar errores de conexión con Web API.

```bash
# Arranca SQL Server
docker-compose up sqlserverdatabase

# Espera 20-30 segundos (hasta ver que SQL está "listening on port 1433")

# Arranca la Web API
docker-compose up prg.webmarket.backend.webapi

# Finalmente, arranca el frontend
docker-compose up frontend
```

Si todo está listo y sincronizado, también puedes ejecutar:

```bash
docker-compose up
```

---

## Accediendo a la Aplicación

- 🌐 **Frontend (Angular):** [http://localhost:4200](http://localhost:4200)
- 🔧 **Backend Swagger (API REST):** [http://localhost:8082/swagger](http://localhost:8082/swagger)

---

## Notas Importantes y Solución de Problemas

### 🐢 WebAPI no conecta con SQL Server

Si WebAPI lanza un error como:

```
A network-related or instance-specific error occurred while establishing a connection to SQL Server
```

➡ **Solución:** El contenedor SQL no ha terminado de iniciar. Detén y vuelve a arrancar WebAPI:

```bash
docker-compose restart prg.webmarket.backend.webapi
```

---



---

## 📬 Contacto

- 📧 **Email:** [pedroramirez_1991@hotmail.com](mailto:pedroramirez_1991@hotmail.com)
- 💼 **LinkedIn:** [Pedro Ramírez González](https://www.linkedin.com/in/pedroramirezgonz/)

---

¡Gracias por usar WebMarket! ¡Disfruta construyendo y aprendiendo! ✨

