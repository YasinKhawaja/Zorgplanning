import { makeStyles } from "@mui/styles";
import React from "react";

const useStyles = makeStyles({
  sideMenu: {
    backgroundColor: "lightblue",
    display: "flex",
    flexDirection: "column",
    height: "100%",
    left: "0px",
    position: "absolute",
    width: "320px",
  },
});

export default function SideMenu() {
  const classes = useStyles();
  return <div className={classes.sideMenu}></div>;
}
