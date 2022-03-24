import NotListedLocationIcon from "@mui/icons-material/NotListedLocation";
import {
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  IconButton,
  Typography,
} from "@mui/material";
import { makeStyles } from "@mui/styles";
import parse from "html-react-parser";
import React from "react";
import Controls from "../controls/Controls";

const useStyles = makeStyles((theme) => ({
  dialog: {
    padding: "16px",
  },
  dialogTitle: { display: "flex", justifyContent: "center" },
  dialogContent: { textAlign: "center", padding: "16px" },
  dialogAction: { justifyContent: "center" },
  titleIcon: {
    backgroundColor: theme.palette.secondary.light,
    color: theme.palette.secondary.main,
    "& .MuiSvgIcon-root": { fontSize: "7rem" },
    "&:hover": {
      cursor: "default",
    },
  },
}));

export default function ConfirmDialog(props) {
  const { confirmDialog, setConfirmDialog } = props;
  const classes = useStyles();
  return (
    <Dialog classes={{ paper: classes.dialog }} open={confirmDialog.open}>
      <DialogTitle className={classes.dialogTitle}>
        <IconButton className={classes.titleIcon} disableRipple>
          <NotListedLocationIcon />
        </IconButton>
      </DialogTitle>
      <DialogContent className={classes.dialogContent}>
        <Typography variant="h5">{parse(confirmDialog.title)}</Typography>
        <Typography variant="subtitle1">
          {parse(confirmDialog.subtitle)}
        </Typography>
      </DialogContent>
      <DialogActions className={classes.dialogAction}>
        <Controls.Button
          text="YES"
          color="secondary"
          onClick={confirmDialog.onConfirm}
        />
        <Controls.Button
          text="NO"
          color="grey"
          onClick={() => setConfirmDialog({ ...confirmDialog, open: false })}
        />
      </DialogActions>
    </Dialog>
  );
}
