import { Card, Paper, Typography } from "@mui/material";
import { makeStyles } from "@mui/styles";
import React from "react";

const useStyles = makeStyles((theme) => ({
  root: { backgroundColor: "#FDFDFF" },
  pageHeader: {
    display: "flex",
    marginBottom: theme.spacing(3),
    padding: theme.spacing(4),
  },
  pageIcon: {
    borderRadius: "12px",
    color: "#3C44B1",
    display: "inline-block",
    padding: theme.spacing(2),
  },
  pageTitle: {
    paddingLeft: theme.spacing(4),
    "& .MuiTypography-subtitle2": {
      opacity: "0.6",
    },
  },
}));

export default function PageHeader(props) {
  const { icon, title, subtitle } = props;
  const classes = useStyles();
  return (
    <Paper className={classes.root} elevation={0} square>
      <div className={classes.pageHeader}>
        <Card className={classes.pageIcon}>{icon}</Card>
        <div className={classes.pageTitle}>
          <Typography component="div" variant="h6">
            {title}
          </Typography>
          <Typography component="div" variant="subtitle2">
            {subtitle}
          </Typography>
        </div>
      </div>
    </Paper>
  );
}
