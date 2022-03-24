import { Box, Card, Paper, Typography } from "@mui/material";
import React from "react";

const useStyles = () => ({
  pageHeader: {
    display: "flex",
    padding: "32px",
  },
  pageIcon: {
    borderRadius: "12px",
    color: "#0000FF",
    padding: "16px",
  },
  pageTitle: {
    paddingLeft: "32px",
    "& .MuiTypography-subtitle2": {
      opacity: "0.6",
    },
  },
});

export default function PageHeader(props) {
  const { icon, title, subtitle } = props;
  const classes = useStyles();
  return (
    <Paper elevation={0} square>
      <Box sx={classes.pageHeader}>
        <Card sx={classes.pageIcon}>{icon}</Card>
        <Box sx={classes.pageTitle}>
          <Typography component="div" variant="h4">
            {title}
          </Typography>
          <Typography component="div" variant="subtitle2">
            {subtitle}
          </Typography>
        </Box>
      </Box>
    </Paper>
  );
}
