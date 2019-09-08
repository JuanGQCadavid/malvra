# Malvra (Proyecto integrador 2)

Sistema de apoyo para floricultura utilizando HoloLens.

### Estructura 
- lib -> Librerias y/o paquetes utilizados
- Unity -> Proyecto en unity para HoloLens
- backend -> Servidor

### Despliegue del cliente HoloLens
#### Requisitos
- Unity
- Visual Studio IDE con Componentes Desarrollo para escritorio con C++ y Desarrollo de UWP
- HoloLens o HoloLens Emulator

#### Construcción en Unity
Cumplidos los requisitos, abrir la carpeta `./unity` en Unity. Una vez cargue el proyecto, ir a build settings, `File->Build Settings...`, cambiar a Universal Windows Platform, y establecer la siguiente configuración:
* Target device -> Any device
* Architecture -> x86
* Build Type -> D3D
* Target SDK -> Lates installed
* Minimum platform version -> 10.0.10240.0
* Visual Studio Version -> Latest installed
* Build and Run on -> Local Machine
* Build configuration -> Release
* Checkboxes -> Unchecked
* Compresion Method -> Default

Hecho esto dar build, elegir el directorio destino y esperar a que termine el proceso. 

#### Despliegue en Emulador
Abrir la solución generada en visual studio, seleccionar el emulador desde el menu desplegable de depuración y desplegar.

#### Despliegue en HoloLens
Abrir la solución generada en visual studio, seleccionar máquina remota desde el menu desplegable de depuración, ir a propiedades del proyecto, en la sección de depuración, poner la dirección ip del dispositivo en el espacio de nombre de máquina remota, finalmente desplegar. 

La ip de las hololens se encuentran en `Settings->Networking->Hardware properties`.

### Despliegue de backend 
