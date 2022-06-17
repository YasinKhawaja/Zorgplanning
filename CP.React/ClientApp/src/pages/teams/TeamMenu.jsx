import DeleteIcon from "@mui/icons-material/Delete";
import EditIcon from "@mui/icons-material/Edit";
import MoreHorizIcon from "@mui/icons-material/MoreHoriz";
import {
  IconButton,
  ListItemIcon,
  ListItemText,
  Menu,
  MenuItem,
  MenuList,
} from "@mui/material";
import React from "react";

export default function TeamMenu(props) {
  const [anchorEl, setAnchorEl] = React.useState(null);
  const open = Boolean(anchorEl);

  React.useEffect(() => {
    setAnchorEl(null);
  }, []);

  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <>
      <TeamIconMenuButton open={open} onClick={handleClick} />
      <TeamMenuList
        anchorEl={anchorEl}
        open={open}
        team={props.team}
        onClose={handleClose}
        onOpenAddOrEditDialog={props.onOpenAddOrEditDialog}
        onOpenDeleteDialog={props.onOpenDeleteDialog}
        onSetTeamToEdit={props.onSetTeamToEdit}
      />
    </>
  );
}

function TeamIconMenuButton(props) {
  return (
    <IconButton
      id="basic-button"
      aria-controls={props.open ? "basic-menu" : undefined}
      aria-haspopup="true"
      aria-expanded={props.open ? "true" : undefined}
      onClick={props.onClick}
    >
      <MoreHorizIcon />
    </IconButton>
  );
}

function TeamMenuList(props) {
  return (
    <Menu
      id="basic-menu"
      anchorEl={props.anchorEl}
      open={props.open}
      onClose={props.onClose}
      MenuListProps={{
        "aria-labelledby": "basic-button",
      }}
    >
      <MenuList disablePadding>
        <MenuItem
          onClick={() => {
            props.onOpenAddOrEditDialog(true);
            props.onSetTeamToEdit(props.team);
          }}
        >
          <ListItemIcon>
            <EditIcon fontSize="small" />
          </ListItemIcon>
          <ListItemText>Bijwerken</ListItemText>
        </MenuItem>
        {!props.team.hasChildren && (
          <MenuItem
            onClick={() => {
              props.onOpenDeleteDialog(true);
              props.onSetTeamToEdit(props.team);
            }}
          >
            <ListItemIcon>
              <DeleteIcon fontSize="small" />
            </ListItemIcon>
            <ListItemText>Verwijderen</ListItemText>
          </MenuItem>
        )}
      </MenuList>
    </Menu>
  );
}
