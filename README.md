# 🔴 RED Operating System (REDos)

![REDos Logo](sandbox:/mnt/data/logo_futurista_de_sistema_operativo_red.png)

REDos és un sistema operatiu educatiu desenvolupat amb C# i Cosmos OS. El projecte ha estat creat amb l’objectiu d’entendre el funcionament intern d’un sistema operatiu: gestió de comandes, sistema de fitxers, gràfics, so i configuració bàsica de xarxa.

---

# 💡 Descripció del SO

REDos és un sistema operatiu simple però funcional que combina:

- 🖥️ Interfície gràfica amb Cosmos Graphic Subsystem
- ⌨️ Sistema de comandes propi
- 🧮 Calculadora integrada
- 📁 Sistema de fitxers FAT32
- 🔊 So del sistema
- 📜 Historial de comandes
- 🌐 Configuració bàsica de xarxa

El sistema està pensat per a finalitats educatives i d’aprenentatge de baix nivell.

---

# 📸 Captures i demo

## Pantalla principal

![REDos UI](https://via.placeholder.com/900x500/000000/ff0000?text=REDos+Graphic+Interface)

## Exemple de calculadora

```txt
REDos> calc

Numero 1: 10
Operacio: *
Numero 2: 5

Resultat: 50
```

## Exemple de sistema de fitxers

```txt
REDos> create
Nom del fitxer: prova.txt
Contingut: Hola REDos!

Fitxer creat correctament.
```

---

# ⚙️ Comandes disponibles

```txt
help       → Mostrar ajuda
calc       → Calculadora
clear      → Netejar pantalla
history    → Historial de comandes
ls         → Llistar fitxers
create     → Crear fitxer
read       → Llegir fitxer
status     → Estat del sistema de fitxers
reboot     → Reiniciar sistema
shutdown   → Apagar sistema
```

---

# 🧮 Calculadora integrada

La calculadora permet:

- ➕ Suma
- ➖ Resta
- ✖ Multiplicació
- ➗ Divisió
- % Mòdul
- √ Arrel quadrada

---

# 🖥️ Interfície gràfica

REDos utilitza Cosmos Graphic Subsystem per generar una interfície gràfica pròpia:

- Barra superior
- Terminal integrada
- Colors personalitzats
- Renderitzat de text amb Canvas
- Sistema d’entrada per teclat

---

# 🔊 Sistema de so

El sistema inclou:

- 🔔 So d’inici
- ✅ So d’èxit
- ❌ So d’error

---

# 🌐 Xarxa

REDos permet:

- Configurar IP estàtica
- Mostrar configuració de xarxa
- Detectar interfícies de xarxa

---

# ⚙️ Tecnologies utilitzades

- 💻 C#
- 🧠 Cosmos OS
- 🖥️ Visual Studio
- 🧪 VMware / VirtualBox
- 🎨 Cosmos Graphic Subsystem
- 💾 Cosmos VFS
- 🔊 Cosmos PC Speaker API

---

# 📦 Instal·lació i ús

## Requisits

- Visual Studio 2022 o superior
- Cosmos User Kit instal·lat
- VMware o VirtualBox

## Execució

```bash
1. Clonar el repositori
2. Obrir REDos.sln
3. Configurar Cosmos
4. Seleccionar VMware/VirtualBox
5. Prémer START ▶
```

---

# 📁 Estructura del projecte

```txt
CosmosKernel1/
│
├── Kernel.cs              → Nucli principal
├── GraphicsManager.cs     → Interfície gràfica
├── InputManager.cs        → Gestió de teclat
├── Calculator.cs          → Calculadora
├── FileSystemManager.cs   → Sistema de fitxers
├── CommandManager.cs      → Historial
├── Sound.cs               → So
├── NetworkManager.cs      → Xarxa
├── UI.cs                  → Interfície i ajuda
```

---

# 👥 Autors

- Eric Alcaraz
- Roger Guardia
- David Fernández

---

# 🚀 Roadmap / Millores futures

- 🌐 Servidor FTP funcional
- 🌍 Xarxa TCP/IP avançada
- 🪟 Sistema de finestres
- 🖱️ Suport de ratolí
- 🧠 Multitasca
- 💾 Millores del sistema de fitxers
- 🎨 Interfície més avançada

---

# 🔥 Conclusió

REDos és un projecte educatiu que permet entendre conceptes interns d’un sistema operatiu real:

- Gestió de hardware
- Sistemes gràfics
- Fitxers
- Xarxa
- Input/Output
- Sons
- Arquitectura modular

El projecte ha estat desenvolupat com a pràctica educativa per explorar el desenvolupament de sistemes operatius amb Cosmos OS.
