import { CssBaseline } from "@mui/material";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { React } from "react";
import Layout from "../components/Layout";
import "./App.css";

const theme = createTheme({
  palette: {
    background: { default: "#f4f5fd" },
  },
});

export default function App() {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Layout />
    </ThemeProvider>
  );
}
