import GroupsIcon from "@mui/icons-material/Groups";
import {
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
} from "@mui/material";
import * as React from "react";
import { NavLink } from "react-router-dom";
import TeamMenu from "./TeamMenu";

export default function TeamsList(props) {
  return (
    <List disablePadding>
      {props.teams.map((team) => (
        <ListItem
          key={team.id}
          secondaryAction={
            <TeamMenu
              team={team}
              onSetTeamToEdit={props.onSetTeamToEdit}
              onOpenAddOrEditDialog={props.onOpenAddOrEditDialog}
              onOpenDeleteDialog={props.onOpenDeleteDialog}
            />
          }
          disablePadding
          divider
        >
          <ListItemButton>
            <ListItemIcon>
              <GroupsIcon color="primary" />
            </ListItemIcon>
            <NavLink
              to={`/teams/${team.id}/employees`}
              style={{ textDecoration: "none", color: "inherit" }}
            >
              <ListItemText primary={team.name} />
            </NavLink>
          </ListItemButton>
        </ListItem>
      ))}
    </List>
  );
}
