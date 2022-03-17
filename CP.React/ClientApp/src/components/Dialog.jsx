import CloseIcon from "@mui/icons-material/Close";
import {
  Dialog as MuiDialog,
  DialogContent,
  DialogTitle,
  Typography,
} from "@mui/material";
import React from "react";
import Controls from "../components/controls/Controls";

export default function Dialog(props) {
  const { children, title, openDialog, setOpenDialog } = props;
  return (
    <MuiDialog open={openDialog} maxWidth="md">
      <DialogTitle>
        <div style={{ display: "flex" }}>
          <Typography component="div" variant="h6" style={{ flexGrow: 1 }}>
            {title}
          </Typography>
          <Controls.ActionButton
            color="secondary"
            onClick={() => setOpenDialog(false)}
          >
            <CloseIcon />
          </Controls.ActionButton>
        </div>
      </DialogTitle>
      <DialogContent dividers>{children}</DialogContent>
    </MuiDialog>
  );
}
