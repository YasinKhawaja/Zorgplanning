import PeopleAltIcon from "@mui/icons-material/PeopleAlt";
import {
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
} from "@mui/material";
import TeamMenu from "./TeamMenu";

export default function TeamList(props) {
  const { team, onUpdate, onDelete } = props;

  const handleUpdate = (id, team) => {
    onUpdate(id, team);
  };

  const handleDelete = (id) => {
    onDelete(id);
  };

  return (
    <List disablePadding sx={{ border: 1, borderColor: "primary.main" }}>
      {props.teams.map((team) => (
        <TeamListItem
          key={team.id}
          team={team}
          onUpdate={handleUpdate}
          onDelete={handleDelete}
        />
      ))}
    </List>
  );
}

function TeamListItem(props) {
  const { team, onUpdate, onDelete } = props;

  const handleUpdate = (id, team) => {
    onUpdate(id, team);
  };

  const handleDelete = (id) => {
    onDelete(id);
  };

  return (
    <ListItem
      secondaryAction={
        <TeamMenu team={team} onUpdate={handleUpdate} onDelete={handleDelete} />
      }
      disablePadding
    >
      <ListItemButton component="a" href={`/teams/${team.id}/employees`}>
        <ListItemIcon>
          <PeopleAltIcon color="primary" />
        </ListItemIcon>
        <ListItemText primary={team.name} />
      </ListItemButton>
    </ListItem>
  );
}
