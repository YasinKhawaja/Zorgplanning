import MoreHorizIcon from "@mui/icons-material/MoreHoriz";
import { IconButton, Menu } from "@mui/material";
import React from "react";
import TeamAddEdit from "./TeamAddEdit";
import TeamRemove from "./TeamRemove";

export default function TeamMenu({ team }) {
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
        <TeamAddEdit team={team} edit="true" />
        <TeamRemove team={team} />
      </Menu>
    </>
  );
}
