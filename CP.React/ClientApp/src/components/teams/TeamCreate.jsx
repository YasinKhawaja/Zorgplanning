import AddIcon from "@mui/icons-material/Add";
import { Box, Button } from "@mui/material";
import React from "react";
import TeamCreateUpdateForm from "./TeamCreateUpdateForm";

export default function TeamCreate(props) {
  const [open, setOpen] = React.useState(false);

  const handleOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleCreate = (team) => {
    props.onCreate(team);
    handleClose();
  };

  return (
    <>
      <Box sx={{ marginTop: 5, textAlign: "center" }}>
        <Button
          onClick={handleOpen}
          startIcon={<AddIcon />}
          variant="contained"
          disableElevation
        >
          CREATE
        </Button>
      </Box>
      <TeamCreateUpdateForm
        open={open}
        onClose={handleClose}
        onCreate={handleCreate}
      />
    </>
  );
}
