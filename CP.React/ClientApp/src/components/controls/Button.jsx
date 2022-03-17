import { Button as MuiButton } from "@mui/material";
import { makeStyles } from "@mui/styles";
import React from "react";

const useStyles = makeStyles((theme) => ({
  root: {
    margin: theme.spacing(0.5),
  },
}));

export default function Button(props) {
  const { color, onClick, size, text, variant, ...other } = props;
  const classes = useStyles();
  return (
    <MuiButton
      className={classes.root}
      color={color || "primary"}
      onClick={onClick}
      size={size || "large"}
      variant={variant || "contained"}
      {...other}
    >
      {text}
    </MuiButton>
  );
}
