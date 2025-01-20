﻿namespace MusicFileWebApp.Service.Services;

public interface IStorageService
{
    void UploadFile(string filePath, Stream stream);

    void CreateDirectory(string? directoryPath, string directoryName);

    List<string> GetAllFilesAndDirectories(string directoryPath);

    Stream DownloadFile(string filePath);

    Stream DownloadDirectory(string directoryPath);

    void DeleteDirectory(string directoryPath);

    void DeleteFile(string filePath);
}