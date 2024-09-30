# MeltdownBoxes

![NuGet Version](https://img.shields.io/nuget/v/MeltdownBoxes)
![GitHub Created At](https://img.shields.io/github/created-at/furkanozturklab/MeltdownBoxes)
![GitHub License](https://img.shields.io/github/license/furkanozturklab/MeltdownBoxes)

## Description

MeltdownBoxes is a **WPF library** of alert and dialog boxes designed to enhance user interactions. With modern and user-friendly interfaces, it offers customizable alert boxes and dialogs that application developers can easily integrate into their projects.

## Installation

To add this package to your project, you can follow the steps below:

### Installation via NuGet

1. Open Visual Studio.
2. Open your project.
3. From the **Tools** menu, select **NuGet Package Manager**, then click on **Manage NuGet Packages for Solution...**.
4. Go to the **Browse** tab and type `MeltdownBoxes` in the search box.
5. Select the package from the list and click the **Install** button.
6. Accept the license agreement.

### Manual Installation

If you prefer not to use NuGet, you can also install the package manually:

1. Download the source code from the [GitHub Repository](https://github.com/furkanozturklab/MeltdownBoxes).
2. Right-click on your project references and select **Add Reference...**.
3. Choose the `.dll` file from the `Bin` folder of the downloaded package and add it.

### Dependencies

To ensure the proper functioning of this package, .NET 8 or a higher version must be present in the project.

Once the installation is complete, you can easily create alert and dialog boxes using the `BoxController` class.

# Usage

Before using the `BoxController` class, you need to **Initialize** the alert and dialog boxes separately. You do not need to **Initialize** the structure you do not wish to use. You can use the following code examples to set up the initial configurations:


## AlertBoxInitialize Method

```csharp

BoxController.AlertBoxInitialize(
    AlertSize.Medium,
    AlertPlacement.Center,
);

```

The `AlertBoxInitialize` method is responsible for initializing alert boxes with specific settings. Below are the parameters, their default values, and additional notes.

### Parameters

| Parameter Name     | Type                 |  Default Value | Required  | Description                                         |
|--------------------|----------------------|---------------|-----------|-----------------------------------------------------|
| `sizeType`         | `AlertSize`          | Enum `AlertSize` | Yes       | The size of the alert box.                          |
| `placement`        | `AlertPlacement`     | Enum `AlertPlacement` | Yes        | The placement of the alert box on the screen.      |
| `popupAnimation`   | `PopupAnimation?`    | `PopupAnimation.Fade`  | No        | The animation type for the alert box popup.        |
| `maxChild`         | `int?`               | `6` | No        | The maximum number of child elements allowed.       |
| `duration`         | `double?`            | `5000` | No        | The duration for which the alert box is displayed.  |
| `maxBuffer`        | `int?`               | `20` | No        | The maximum buffer size for alert messages.         |

### Notes

If the above values ​​are not provided, the `AlertBoxInitialize` method will work with the parameters and default values ​​you define as mandatory.

## DialogBoxInitialize Method

```csharp

BoxController.DialogBoxInitialize(
    DialogSize.Large,
    DialogPlacement.Center,
);

```

The `DialogBoxInitialize` method is responsible for initializing dialog boxes with specific settings. Below are the parameters, their default values, and additional notes.

### Parameters

| Parameter Name      | Type                  | Default Value      | Required  | Description                                          |
|---------------------|-----------------------|--------------------|-----------|------------------------------------------------------|
| `sizeType`          | `DialogSize`          | Enum `DialogSize`  | Yes       | The size of the dialog box.                          |
| `dialogPlacement`    | `DialogPlacement`     | Enum `DialogPlacement` | Yes       | The placement of the dialog box on the screen.      |
| `screenPadding`     | `int`                 | `10`               | No        | The padding around the dialog box on the screen.    |

### Notes

If the above values ​​are not provided, the `DialogBoxInitialize` method will work with the parameters and default values ​​you define as mandatory.


After these operations, both the `AlertBox` and `Dialog Box` structures will be ready for use. If you continue without performing these initializations, the methods will throw an error.


```csharp

// Since dialog boxes are async structures, you must wait with await.

    if(await BoxController.ConfirmedDialog("Do you want to proceed with this action?","Confirmation")){
        MessageBox.Show("User continues.");
    }
    else{
        MessageBox.Show("User does not continue.");
    }

// AlertBoxes do not require a result, so you do not need to wait with await.

    BoxController.Warning($"{DateTime.Now}", "Warning");

```

## Examples

All `AlertBoxes` and `DialogBoxes` that you can call are shown below.

### Alert Boxes Examples

```csharp

        // ALL ALERTBOXES

        Random random = new Random();
        int randomNumber = random.Next(1, 6);


        switch (randomNumber)
        {
            case 1:
                BoxController.Warning($"{DateTime.Now}", "Warning");
                break;
            case 2:
                BoxController.Error($"{DateTime.Now}", "Error");
                break;
            case 3:
                BoxController.Success($"{DateTime.Now}", "Success");
                break;
            case 4:
                BoxController.Information($"{DateTime.Now}", "Information");
                break;
            default:
                BoxController.Other($"{DateTime.Now}", "Other");
                break;
        }

```

This image shows all the `AlertBox` structures that can be used in the package.

![AlertBoxes](https://i.imgur.com/mGwJAT5.png)

### DialogBoxes

This image also shows the example of `ConfirmedDialog` in the package.

```csharp
    var x = await BoxController.ConfirmedDialog("Are you sure you want to delete this item ?", "Delete Confirmation");

```

![ConfirmedDialog](https://i.imgur.com/U9ZMiat.png)

This image also shows the example of `ContinueDialog` in the package.

```csharp
    var x1 = await BoxController.ContinueDialog(""Are you sure you want to continue with this operation ?", "Continue");

```

![ContinueDialog](https://i.imgur.com/wMJFv3Q.png)

This image also shows the example of `RetryDialog` in the package.

```csharp
    var x2 = await BoxController.RetryDialog("An error occurred while processing. Would you like to try again ?", "Retry Operation");

```

![RetryDialog](https://i.imgur.com/MsOVd7x.png)


This image also shows the example of `WarningDialog` in the package.

```csharp
    var x3 = await BoxController.WarningDialog("You have unsaved changes. Are you sure you want to exit ?", "Warning");
```

![WarningDialog](https://i.imgur.com/Krj4Js9.png)


# Contributing

MeltdownBoxes is presented as an open-source project. Therefore, anyone can contribute to the project and help enhance the features of MeltdownBoxes.

### How to Contribute?

Developers who want to contribute to the project can visit the GitHub page and click the `Fork` button to create a copy in their accounts. They can then clone the project copy to their computers to make changes.

After making changes, developers should commit their work and push it back to their GitHub page. Finally, they can submit a `Pull Request` on the original GitHub page to integrate their changes into the original project.

### How to Help?

Developers who want to help with the project can check the `Issues` section on the GitHub page. This section lists the features and problems that need to be addressed for the project's development. Developers can contribute by solving these issues or developing new features.

Additionally, assistance can be provided in improving the project's documentation or adding new features. This can be done by downloading the project copy or editing the files on the GitHub page.

# Contact

For any questions, suggestions, or feedback regarding the project, you can reach me at:

- Email: info@furkanozturklab.com
- X: [@nakruf_oz](https://x.com/nakruf_oz)

You can also share your issues or suggestions in the `Issues` section on the project's GitHub page.

By reaching out to us, you can help improve the project. Your suggestions and feedback are important to us and contribute to making the project better.
