# Blazor Feature Rich DataGrid

## Overview

This repository contains a feature-rich Syncfusion [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) sample application designed to demonstrate multiple DataGrid capabilities within a single project. The solution includes separate implementations for both Blazor Server and Blazor WebAssembly hosting models, enabling developers to explore DataGrid functionality in different Blazor environments. The sample serves as a reference application for understanding how Syncfusion Blazor DataGrid features can be configured and combined within a real-world project structure.

## Key Features

- Demonstrates Syncfusion Blazor DataGrid functionality in both Blazor Server and Blazor WebAssembly applications.
- Includes separate Server and WASM sample projects for comparing deployment models.
- Provides an integrated showcase of DataGrid features within a single application.
- Uses Syncfusion Blazor DataGrid components as the primary user interface for displaying and interacting with data.
- Serves as a consolidated reference sample for developers evaluating DataGrid capabilities.

## Prerequisites

- Visual Studio 2022 or Visual Studio Code
- .NET SDK compatible with the project's target framework

## How to Run the Project

**Visual Studio 2022**

1. Clone or download this repository.
2. Open the solution file located in either the `FeatureRichGrid_Server` or `FeatureRichGrid_Wasm` project folder.
3. Restore all NuGet packages.
4. Set the appropriate startup project if required.
5. Build the solution.
6. Run the project using `Ctrl+F5`.

**Visual Studio Code**

1. Open the repository folder in Visual Studio Code.
2. Open the integrated terminal.
3. Navigate to the appropriate project directory.

```bash
dotnet restore
dotnet run
```

4. Open the local application URL displayed after the project starts.

## Project Structure

- `FeatureRichGrid_Server/` — contains the Blazor Server implementation of the feature-rich Syncfusion DataGrid sample.
- `FeatureRichGrid_Wasm/` — contains the Blazor WebAssembly implementation of the feature-rich Syncfusion DataGrid sample.
- `FeatureRichGrid_Server/Pages/` — hosts the Blazor pages containing the Syncfusion DataGrid implementation. 
- `FeatureRichGrid_Wasm/Pages/` — hosts the WebAssembly pages containing the Syncfusion DataGrid implementation.

## Support and Feedback

- For general product questions, visit the [Syncfusion Community Forum](https://www.syncfusion.com/forums) or [Syncfusion Support](https://www.syncfusion.com/support).
- To report an issue specific to this sample, open a GitHub issue in this repository.
- For official Syncfusion Blazor DataGrid documentation, see https://help.syncfusion.com/grid-sdk/blazor/data-grid/getting-started

## License

This is a Syncfusion sample project provided to demonstrate product usage. Review the [Syncfusion license terms](https://www.syncfusion.com/sales/pricing?category=ui-components) before using Syncfusion components in your own applications.
