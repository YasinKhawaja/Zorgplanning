import { Paper } from "@mui/material";
import React from "react";

const useStyles = () => ({
  main: { margin: "40px", marginTop: "40px", padding: "24px" },
});

export default function Main(props) {
  const { children } = props;

  const classes = useStyles();

  return (
    <Paper component={"main"} elevation={0} sx={classes.main}>
      {children}
    </Paper>
  );
}
