import DeleteIcon from "@mui/icons-material/Delete";
import EditIcon from "@mui/icons-material/Edit";
import MoreHorizIcon from "@mui/icons-material/MoreHoriz";
import { IconButton, Menu, MenuItem } from "@mui/material";
import React from "react";

export default function TeamMenu(props) {
  const [anchorEl, setAnchorEl] = React.useState(null);
  const open = Boolean(anchorEl);

  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <>
      <IconButton
        id="basic-button"
        aria-controls={open ? "basic-menu" : undefined}
        aria-haspopup="true"
        aria-expanded={open ? "true" : undefined}
        onClick={handleClick}
      >
        <MoreHorizIcon />
      </IconButton>
      <Menu
        id="basic-menu"
        anchorEl={anchorEl}
        open={open}
        onClose={handleClose}
        MenuListProps={{
          "aria-labelledby": "basic-button",
        }}
      >
        <MenuItem
          onClick={() => {
            props.onOpenAddOrEditDialog(true);
            props.onSetTeamToEdit(props.team);
          }}
        >
          <EditIcon color="success" fontSize="small" />
          Edit
        </MenuItem>
        {!props.team.hasChildren && (
          <MenuItem
            onClick={() => {
              props.onOpenDeleteDialog(true);
              props.onSetTeamToEdit(props.team);
            }}
          >
            <DeleteIcon color="error" fontSize="small" />
            Delete
          </MenuItem>
        )}
      </Menu>
    </>
  );
}
