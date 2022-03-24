import ChatBubbleIcon from "@mui/icons-material/ChatBubble";
import NotificationsIcon from "@mui/icons-material/Notifications";
import PowerSettingsNewIcon from "@mui/icons-material/PowerSettingsNew";
import { AppBar, Badge, Grid, IconButton, Toolbar } from "@mui/material";
import React from "react";

const useStyles = () => ({
  header: { backgroundColor: "#E8F4F8", transform: "translateZ(0)" },
});

export default function Header() {
  const classes = useStyles();
  return (
    <AppBar sx={classes.header} position="static">
      <Toolbar>
        <Grid alignItems="center" container>
          <Grid item></Grid>
          <Grid item sm />
          <Grid item>
            <IconButton>
              <Badge badgeContent={1} color="secondary">
                <NotificationsIcon fontSize="small" />
              </Badge>
            </IconButton>
            <IconButton>
              <Badge badgeContent={1} color="primary">
                <ChatBubbleIcon fontSize="small" />
              </Badge>
            </IconButton>
            <IconButton>
              <PowerSettingsNewIcon fontSize="small" />
            </IconButton>
          </Grid>
        </Grid>
      </Toolbar>
    </AppBar>
  );
}
