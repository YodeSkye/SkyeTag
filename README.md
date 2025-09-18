
# 🎵 SkyeTag

**SkyeTag** is a lightweight Windows application for managing and enriching audio file metadata. It leverages the power of [SkyeLibrary](https://github.com/your-org/SkyeLibrary), [TagLibSharp](https://github.com/mono/taglib-sharp), and the [MusicBrainz](https://musicbrainz.org/) APIs to provide accurate tagging and cover art retrieval.

---

## 🚀 Features

- Read and edit metadata for MP3, FLAC, and other audio formats
- Fetch cover art from MusicBrainz
- Clean and intuitive WinForms interface

---

## 📦 Dependencies

To build and run SkyeTag, the following packages and references are required:

### 🔧 NuGet Packages

Install these via **Package Manager Console** or `.csproj` references:

```powershell
Install-Package SkyeLibrary
Install-Package TagLibSharp
Install-Package Microsoft.VisualBasic
Install-Package MetaBrainz.MusicBrainz
Install-Package MetaBrainz.MusicBrainz.CoverArt
```

> 📌 Note: These packages target **.NET 6.0** or higher.

- **SkyeLibrary**: Utilities and UI controls for SkyeTag (local or GitHub-hosted `.nupkg`)
- **TagLibSharp**: Reads/writes metadata from audio files
- **Microsoft.VisualBasic**: Required for legacy compatibility and certain WinForms features
- **MetaBrainz.MusicBrainz**: Interfaces with the MusicBrainz API for album and artist data
- **MetaBrainz.MusicBrainz.CoverArt**: Retrieves album artwork from the Cover Art Archive

---

## 🛠 Installing SkyeLibrary Locally

If you're using a local `.nupkg` file for SkyeLibrary:

1. Open **Visual Studio**
2. Go to **Tools > NuGet Package Manager > Package Manager Console**
3. Run the following command:

    ```powershell
    Install-Package SkyeLibrary -Source "C:\Path\To\Your\Package"
    ```

    > 💡 Example:
    > ```powershell
    > Install-Package SkyeLibrary -Source "C:\Users\YourName\Downloads"
    > ```

Make sure the **Default Project** dropdown is set to your target project.

---

## 📚 Resources

- [TagLibSharp GitHub](https://github.com/mono/taglib-sharp)
- [MetaBrainz.MusicBrainz NuGet](https://www.nuget.org/packages/MetaBrainz.MusicBrainz)
- [MetaBrainz.MusicBrainz.CoverArt NuGet](https://www.nuget.org/packages/MetaBrainz.MusicBrainz.CoverArt)
- [MusicBrainz API Docs](https://musicbrainz.org/doc/Development/XML_Web_Service/Version_2)

---

## 🤝 Contributing

Pull requests are welcome! For major changes, please open an issue first to discuss what you’d like to change.

---

## 📄 License

This project is licensed under the GNU GENERAL PUBLIC LICENSE v3.
