import CloseIcon from "@mui/icons-material/Close";
import {
  Dialog as MuiDialog,
  DialogContent,
  DialogTitle,
  Typography,
} from "@mui/material";
import parse from "html-react-parser";
import React from "react";
import Controls from "../controls/Controls";

const useStyles = () => ({
  dialogTitle: {
    display: "flex",
    justifyContent: "space-between",
  },
});

export default function Dialog(props) {
  const { children, title, openDialog, setOpenDialog, sx } = props;
  const classes = useStyles();
  return (
    <MuiDialog open={Boolean(openDialog)} maxWidth="lg" sx={sx}>
      <DialogTitle sx={classes.dialogTitle}>
        <div style={{ display: "table" }}>
          <div style={{ display: "table-cell", verticalAlign: "middle" }}>
            <Typography component="div" variant="h5">
              {parse(title)}
            </Typography>
          </div>
        </div>
        <Controls.ActionButton
          color="secondary"
          onClick={() => setOpenDialog(false)}
        >
          <CloseIcon />
        </Controls.ActionButton>
      </DialogTitle>
      <DialogContent dividers>{children}</DialogContent>
    </MuiDialog>
  );
}
