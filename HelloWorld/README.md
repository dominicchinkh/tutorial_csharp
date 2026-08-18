# Setting Up C# and .NET on WSL (Ubuntu 24.04)

This guide provides a step-by-step walkthrough for installing .NET SDK, setting up a C# console application, and running/building your first project within **Windows Subsystem for Linux (WSL 2)** running **Ubuntu 24.04 LTS**.

---

## 📋 Prerequisites

Before starting, ensure you have:
1. **WSL 2** installed on Windows 10/11 with **Ubuntu 24.04 LTS**.
2. Terminal access to your WSL environment.

---

## 🚀 Quick Setup (All-in-One Command)

If you want to run the setup and verification steps in one execution block, run the following in your WSL terminal:

```bash
sudo apt-get update && sudo apt-get install -y dotnet-sdk-10.0 && sudo apt-get update && sudo apt-get install -y aspnetcore-runtime-10.0 && dotnet --version && dotnet new console -o HelloWorld && cd HelloWorld && dotnet run && dotnet build
```

---

## 🛠️ Step-by-Step Installation & Verification

### Step 1: Update Package Lists and Install .NET SDK

Install the .NET 10.0 Software Development Kit (SDK) which includes the compiler, CLI, and base libraries:

```bash
sudo apt-get update && sudo apt-get install -y dotnet-sdk-10.0
```

### Step 2: Install ASP.NET Core Runtime

Install the ASP.NET Core Runtime for web API and server application support:

```bash
sudo apt-get update && sudo apt-get install -y aspnetcore-runtime-10.0
```

> **Note:** Installing the SDK already includes the runtime, but installing `aspnetcore-runtime-10.0` explicitly ensures all web runtime dependencies are fully resolved.

### Step 3: Verify the Installation

Confirm that the .NET CLI is properly installed and accessible in your PATH:

```bash
dotnet --version
```

---

## 💻 Creating and Running Your First Application

### Step 4: Create a New Console Application

Generate a standard C# console project named `HelloWorld`:

```bash
dotnet new console -o HelloWorld
```

### Step 5: Navigate to Project Directory

```bash
cd HelloWorld
```

### Step 6: Run the Application

Compile and execute the program in a single step:

```bash
dotnet run
```

Compile and execute a CS file in a single step:

```bash
dotnet run HelloWorld.cs
```

### Step 7: Build the Application

Compile the project binaries into the `bin/` directory without running:

```bash
dotnet build
```

---

## 📁 Project Structure Overview

After following these steps, your project directory will look like this:

```
HelloWorld/
├── HelloWorld.csproj   # Project configuration & dependency file
├── Program.cs          # Main C# source file
├── bin/                # Output binaries (Debug/Release)
└── obj/                # Intermediate build files & NuGet caches
```

---

## 💡 Troubleshooting & Notes

* **Package Not Found Error:** If `dotnet-sdk-10.0` is not found in the Ubuntu 24.04 repositories, ensure you have the Microsoft Package Repository added to apt or substitute with `dotnet-sdk-8.0` / `dotnet-sdk-9.0` depending on repository availability:
  ```bash
  sudo apt-get install -y dotnet-sdk-8.0
  ```
* **VS Code WSL Extension:** To edit your project in VS Code on Windows while staying in WSL, type:
  ```bash
  code .
  ```