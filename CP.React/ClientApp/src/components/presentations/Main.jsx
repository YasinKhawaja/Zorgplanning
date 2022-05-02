import { Paper } from "@mui/material";
import React from "react";

const useStyles = () => ({
  main: { margin: "40px", marginTop: "110px", padding: "24px" },
});

export default function Main(props) {
  const classes = useStyles();
  const { children } = props;
  return (
    <Paper sx={classes.main} component={"main"}>
      {children}
    </Paper>
  );
}
