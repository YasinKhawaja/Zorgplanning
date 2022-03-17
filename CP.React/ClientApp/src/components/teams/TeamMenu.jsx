import MoreHorizIcon from "@mui/icons-material/MoreHoriz";
import { IconButton, Menu } from "@mui/material";
import React from "react";
import TeamDelete from "./TeamDelete";
import TeamUpdate from "./TeamUpdate";

export default function TeamMenu(props) {
  const [anchorEl, setAnchorEl] = React.useState(null);
  const open = Boolean(anchorEl);

  const { team, onUpdate, onDelete } = props;

  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  const handleUpdate = (id, team) => {
    onUpdate(id, team);
  };

  const handleDelete = (id) => {
    onDelete(id);
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
        <TeamUpdate team={team} onUpdate={handleUpdate} />
        <TeamDelete team={team} onDelete={handleDelete} />
      </Menu>
    </>
  );
}
