import { Button as MuiButton } from "@mui/material";
import React from "react";

const useStyles = () => ({
  root: {
    margin: "0px",
  },
});

export default function Button(props) {
  const { color, onClick, size, text, variant, ...other } = props;
  const classes = useStyles();
  return (
    <MuiButton
      sx={classes.root}
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
