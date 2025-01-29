# Insta Post Generator

This program generates Instagram post images from text input. It reads lines of text from an input file, renders each line using multiple fonts, and saves the images with a simple numbering system.

## Features

- Reads text from `input.txt`
- Supports multiple fonts including emoji support
- Centers and justifies text in the image
- Saves images with a simple numbering system

## Requirements

- .NET Core
- SkiaSharp

## Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/insta_post_generator.git
    cd insta_post_generator
    ```

2. Install the required packages:
    ```sh
    dotnet add package SkiaSharp
    ```

## Usage

1. Place your text input in `input.txt` in the root folder.
2. Run the program:
    ```sh
    dotnet run
    ```
3. The generated images will be saved in a folder named `Images_yyyyMMdd_HHmmss` in the root directory.

## Customization

You can customize the following parameters in the [Program.cs](http://_vscodecontentref_/0) file:

- `inputFilePath`: Path to the input text file.
- `backgroundColor`: Background color of the images.
- [outputFolderPath](http://_vscodecontentref_/1): Path to the output folder.
- [imageWidth](http://_vscodecontentref_/2): Width of the generated images.
- [imageHeight](http://_vscodecontentref_/3): Height of the generated images.
- `fonts`: List of fonts to use for rendering text.

## Example

Here is an example of the text input and the generated images:

### Input (`input.txt`)
