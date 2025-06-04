# Desafío .NET MAUI

## Descripción General
Este repositorio contiene un proyecto de desafío .NET MAUI para que los candidatos demuestren sus habilidades en el desarrollo de aplicaciones móviles. El proyecto presenta una aplicación de contactos que obtiene datos de usuarios de una API externa y los muestra en una lista.

**Tiempo estimado para completar el desafío**: 7-12 horas de trabajo efectivo.

## Ejercicios del Desafío

### Ejercicio 1: Implementación de Arquitectura MVVM
La aplicación actual no sigue el patrón de arquitectura MVVM (Model-View-ViewModel), lo que dificulta su mantenimiento y escalabilidad:

1. **Refactorizar la Estructura del Proyecto**:
   - Crear una estructura de carpetas adecuada para MVVM (Models, Views, ViewModels, Services).
   - Mover los archivos existentes a sus carpetas correspondientes.

2. **Implementar ViewModels**:
   - Crear un ViewModel para la página de contactos que maneje la lógica de presentación.
   - Implementar INotifyPropertyChanged para la actualización de la UI.
   - Utilizar Commands para manejar acciones de usuario (como mostrar contraseña).

3. **Implementar Servicios**:
   - Crear un servicio para el consumo de API que sea inyectable.
   - Implementar inyección de dependencias para facilitar las pruebas unitarias.

### Ejercicio 2: Optimización de Consumo de Servicios y Paginación
La aplicación actualmente carga 100 contactos a la vez desde la API, lo que genera tiempos de carga prolongados y una experiencia de usuario deficiente. Para mejorar esto, se requiere implementar un sistema de paginación eficiente:

1. **Implementación de Paginación con CollectionView**:
   - Reemplazar el actual `BindableLayout` con un `CollectionView` para mejor rendimiento con grandes conjuntos de datos.
   - Implementar el evento `RemainingItemsThreshold` para detectar cuando el usuario está cerca del final de la lista.
   - Utilizar el evento `ThresholdReached` para cargar automáticamente la siguiente página de contactos.
   - Limitar la carga a un máximo de 10 páginas para evitar consumo excesivo de datos.

2. **Modificación de la Solicitud API**:
   - Reducir el número de resultados por página (`results=10` en lugar de `results=100`).
   - Implementar un método `LoadMoreContacts()` que se active cuando se alcance el umbral de desplazamiento.
   - Mantener un contador de página actual para solicitar la página correcta en cada carga.
   - Añadir una condición para detener la carga cuando se alcance la página 10.

3. **Gestión de Estado**:
   - Agregar propiedades para controlar el estado de carga: `IsLoading`, `IsLoadingMore`, `HasMoreItems`.
   - Implementar indicadores visuales para mostrar el estado de carga (spinner al final de la lista).
   - Añadir un mecanismo para evitar cargas duplicadas mientras una solicitud está en progreso.

5. **Control de Errores y Reintentos**:
   - Implementar manejo de excepciones específicas para problemas de red.
   - Añadir lógica de reintento con retraso exponencial para errores temporales.

6. **Optimización de Rendimiento**:
   - Reciclar vistas para minimizar el uso de memoria y mejorar el rendimiento.
   - Considerar la precarga de la siguiente página antes de que el usuario llegue al final.

### Ejercicio 3: Corrección de Mapeo JSON
Existen errores en la configuración del mapeo JSON que impiden que algunos datos se muestren correctamente:

1. **Propiedades JSON Incorrectas**:
   - En `ContactModel.cs`, algunas propiedades tienen nombres de atributos JSON incorrectos.
   - Identificar y corregir todos los nombres de propiedades JSON incorrectos.

### Ejercicio 4: Implementación de Algoritmo ROT13
El cifrado de contraseñas usando ROT13 está incompleto:

1. **Completar el Método ROT13**:
   - Implementar correctamente el algoritmo ROT13 en el método `rot13Password()`.
   - El algoritmo debe reemplazar cada letra por la letra que está 13 posiciones más adelante en el alfabeto.
   - Por ejemplo: 'A' → 'N', 'B' → 'O', 'Z' → 'M', manteniendo mayúsculas/minúsculas y dejando los caracteres no alfabéticos sin cambios.

### Ejercicio 5: Implementación de Navegación a Detalles de Contacto
Se debe implementar una navegación detallada cuando el usuario seleccione un contacto de la lista:

1. **Crear Página de Detalles**:
   - Implementar una nueva página `ContactDetailPage` que muestre información detallada de un contacto.
   - La página debe mostrar la imagen de perfil del contacto y la información importante como nombre, email, género, nacionalidad, teléfonos, edad y fecha de nacimiento.

2. **Implementar Navegación**:
   - Añadir manejo de eventos para detectar cuando se hace clic en un elemento de la lista.
   - Navegar a la página de detalles pasando el contacto seleccionado como parámetro.

3. **Visualización de Detalles**:
   - Mostrar claramente toda la información importante del contacto.
   - Opcional: Implementar una interfaz de usuario atractiva para la página de detalles.

### Ejercicio 6: Mejoras de UI/UX (Opcional)
La interfaz de usuario actual es funcional pero puede mejorarse:

1. **Mejoras Visuales**:
   - Optimizar el espaciado, colores y diseño general.
   - Mejorar la presentación de la información de contacto.

2. **Mejoras de Usabilidad**:
   - Implementar un modo oscuro/claro.
   - Cualquier otra mejora que considere beneficiosa para la experiencia del usuario.

## Estructura del Proyecto

- `Models/ContactModel.cs` - Contiene los modelos de datos para contactos y respuestas de API
- `Views/ContactsPage.xaml` - La definición de UI XAML para la página de contactos
- `Views/ContactsPage.xaml.cs` - El archivo code-behind que contiene la lógica para la página de contactos
- `Helpers/PasswordHelper.cs` - Clase estática que contiene el método rot13 para el cifrado de contraseñas

## Criterios de Evaluación

Los candidatos serán evaluados según:

1. Implementación correcta de la arquitectura MVVM y patrones de diseño
2. Capacidad para implementar paginación eficiente y manejo de estados de carga
3. Habilidad para identificar y solucionar problemas de mapeo de datos
4. Implementación correcta del algoritmo ROT13
5. Calidad general del código: organización, comentarios, manejo de errores
6. Estandarización del código y convenciones de nomenclatura:
   - Seguimiento de las convenciones de C# y .NET MAUI
7. (Opcional) Mejoras de UI/UX y creatividad en las soluciones

## Comenzando

1. Clona este repositorio
2. Crea una rama local o realiza un fork del repositorio:
   - Para crear una rama local: `git checkout -b solucion/tu-nombre`
   - Para hacer un fork: Utiliza el botón "Fork" en GitHub y luego clona tu fork
3. Abre la solución en Visual Studio 2022 (Windows) o Visual Studio for Mac con la carga de trabajo de .NET MAUI instalada
4. Ejecuta el proyecto en tu plataforma preferida (Android, iOS, Windows o macOS)
5. Completa los ejercicios propuestos
6. Envía tu solución:
   - Si usaste una rama local: Sube la rama con `git push origin solucion/tu-nombre` y crea un Pull Request
   - Si usaste un fork: Sube tus cambios a tu fork y crea un Pull Request desde GitHub

## Documentación Importante

Para completar este desafío, te recomendamos consultar la siguiente documentación:

- [Documentación oficial de .NET MAUI](https://learn.microsoft.com/es-es/dotnet/maui/)
- [Algoritmo ROT13](https://en.wikipedia.org/wiki/ROT13)
- [Convenciones de código de C#](https://learn.microsoft.com/es-es/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [Random User API](https://randomuser.me/documentation) - API utilizada para obtener los datos de contactos
- [Parámetros de paginación de Random User API](https://randomuser.me/documentation#pagination) - Documentación específica sobre cómo implementar la paginación con esta API

¡Buena suerte!
