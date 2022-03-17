import { makeStyles } from "@mui/styles";
import React from "react";

const useStyles = makeStyles({
  appMain: { paddingLeft: "320px", width: "100%" },
});

export default function Main(props) {
  const classes = useStyles();
  const { children } = props;
  return <main>{children}</main>;
}
