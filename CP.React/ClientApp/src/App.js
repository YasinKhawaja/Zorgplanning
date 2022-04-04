import AdapterMoment from "@mui/lab/AdapterMoment";
import LocalizationProvider from "@mui/lab/LocalizationProvider";
import { CssBaseline } from "@mui/material";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { React } from "react";
import "./App.css";
import Layout from "./components/Layout";

const theme = createTheme({
  palette: {
    primary: { light: "#ADD8E6", main: "#0000FF" },
    secondary: { light: "#FFCCCB", main: "#FF0000" },
  },
});

export default function App() {
  return (
    <ThemeProvider theme={theme}>
      <LocalizationProvider dateAdapter={AdapterMoment}>
        <CssBaseline />
        <Layout></Layout>
      </LocalizationProvider>
    </ThemeProvider>
  );
}
