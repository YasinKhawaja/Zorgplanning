import GroupsIcon from "@mui/icons-material/Groups";
import {
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
} from "@mui/material";
import TeamMenu from "./TeamMenu";

const useStyles = () => ({ list: { border: 1, borderColor: "primary.main" } });

export default function TeamsList(props) {
  const classes = useStyles();
  return (
    <List sx={classes.list} disablePadding>
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
