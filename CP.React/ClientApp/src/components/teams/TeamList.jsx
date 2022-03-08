import PeopleAltIcon from "@mui/icons-material/PeopleAlt";
import {
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
} from "@mui/material";
import TeamMenu from "./TeamMenu";

export default function TeamList({ teams }) {
  const renderTeamItem = (team) => {
    return (
      <ListItem
        key={team.id}
        secondaryAction={<TeamMenu team={team} />}
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
  };

  return (
    <List disablePadding sx={{ border: 1, borderColor: "primary.main" }}>
      {teams.map((team) => renderTeamItem(team))}
    </List>
  );
}
