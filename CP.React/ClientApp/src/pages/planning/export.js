import axios from "axios";
import { saveAs } from "file-saver";

export async function downloadFile(url, fetchProps) {
  try {
    const response = await fetch(url, fetchProps);

    if (!response.ok) {
      throw new Error(response);
    }

    // Extract filename from header
    const filename = response.headers
      .get("content-disposition")
      .split(";")
      .find((n) => n.includes("filename="))
      .replace("filename=", "")
      .trim();
    const blob = await response.blob();

    // Download the file
    saveAs(blob, filename);
  } catch (error) {
    throw new Error(error);
  }
}
