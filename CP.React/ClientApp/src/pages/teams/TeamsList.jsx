import GroupsIcon from "@mui/icons-material/Groups";
import {
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
} from "@mui/material";
import * as React from "react";
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
          <ListItemButton component="a" href={`/teams/${team.id}/employees`}>
            <ListItemIcon>
              <GroupsIcon color="primary" />
            </ListItemIcon>
            <ListItemText primary={team.name} />
          </ListItemButton>
        </ListItem>
      ))}
    </List>
  );
}
