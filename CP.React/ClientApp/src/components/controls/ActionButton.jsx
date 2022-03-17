import { Button } from "@mui/material";
import { makeStyles } from "@mui/styles";
import React from "react";

const useStyles = makeStyles((theme) => ({
  root: { minWidth: 0, margin: theme.spacing(0.5) },
  primary: {
    backgroundColor: theme.palette.primary.light,
    "& .MuiButton-label": { color: theme.palette.primary.main },
  },
  secondary: {
    backgroundColor: theme.palette.secondary.light,
    "& .MuiSvgIcon-root": { color: theme.palette.secondary.main },
  },
}));

export default function ActionButton(props) {
  const { children, color, onClick } = props;
  const classes = useStyles();
  return (
    <Button onClick={onClick} className={`${classes.root} ${classes[color]}`}>
      {children}
    </Button>
  );
}
