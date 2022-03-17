import AdapterMoment from "@mui/lab/AdapterMoment";
import LocalizationProvider from "@mui/lab/LocalizationProvider";
import {
  createTheme,
  CssBaseline,
  StyledEngineProvider,
  ThemeProvider,
} from "@mui/material";
import { React } from "react";
import "./App.css";
import { Layout } from "./components/Layout";

const theme = createTheme({
  palette: {
    primary: {
      light: "#ADD8E6",
      main: "#0000FF",
    },
    secondary: {
      light: "#FFCCCB",
      main: "#FF0000",
    },
    background: {
      default: "#F4F5FD !important",
    },
  },
  components: {
    MuiAppBar: {
      styleOverrides: {
        root: {
          transform: "translateZ(0)",
        },
      },
    },
  },
});

export default function App() {
  return (
    // <StyledEngineProvider injectFirst>
    <ThemeProvider theme={theme}>
      <LocalizationProvider dateAdapter={AdapterMoment}>
        <CssBaseline />
        <Layout></Layout>
      </LocalizationProvider>
    </ThemeProvider>
    // </StyledEngineProvider>
  );
}
