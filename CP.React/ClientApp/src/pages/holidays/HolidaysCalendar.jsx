import bootstrap5Plugin from "@fullcalendar/bootstrap5";
import nlLocale from "@fullcalendar/core/locales/nl";
import dayGridPlugin from "@fullcalendar/daygrid";
import interactionPlugin from "@fullcalendar/interaction";
import FullCalendar from "@fullcalendar/react"; // MUST BE IMPORTED BEFORE PLUGINS
import timeGridPlugin from "@fullcalendar/timegrid";
import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  Grid,
  Skeleton,
} from "@mui/material";
import "bootstrap-icons/font/bootstrap-icons.css";
import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import { SuccessSnackbar } from "../../components/presentations/Snackbars";
import DateService from "../../services/DateService";
import HolidayForm from "./HolidayForm";
import { mapHolidaysToEvents } from "./holidays-utils";

export default function HolidaysCalendar() {
  const [events, setEvents] = React.useState(null);
  const [openAddOrEditDialog, setOpenAddOrEditDialog] = React.useState(false);
  const [openDeleteDialog, setOpenDeleteDialog] = React.useState(false);
  const [selectedDay, setSelectedDay] = React.useState(null);
  const [eventInfo, setEventInfo] = React.useState(null);
  const [apiErrors, setApiErrors] = React.useState(null);
  const [snackbar, setSnackbar] = React.useState({
    open: false,
    message: "",
  });

  React.useEffect(() => {
    fetchEvents();
  }, []);

  React.useEffect(() => {
    if (!openAddOrEditDialog) {
      setApiErrors(null);
    }
  }, [openAddOrEditDialog]);

  const fetchEvents = () => {
    DateService.getAllHolidays()
      .then((response) => {
        setEvents(mapHolidaysToEvents(response.data.result));
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const handleDateSelect = (selectInfo) => {
    setSelectedDay(selectInfo);
    setOpenAddOrEditDialog(true);
  };

  const handleEventClick = (clickInfo) => {
    setEventInfo(clickInfo);
    setOpenDeleteDialog(true);
  };

  const handleAddOrEdit = (values, resetFormFn) => {
    const holiday = {
      ...values,
      date: selectedDay.dateStr,
    };
    const data = JSON.stringify(holiday);
    DateService.addHoliday(data)
      .then(() => {
        resetFormFn();
        setOpenAddOrEditDialog(false);
        fetchEvents();
        setSnackbar({
          ...snackbar,
          open: true,
          message: "Feestdag succesvol toegevoegd",
        });
      })
      .catch((error) => {
        setApiErrors(error.response.data.errors);
      });
  };

  const handleDelete = (event) => {
    DateService.removeHoliday(event.startStr)
      .then(() => {
        setOpenDeleteDialog(false);
        fetchEvents();
        setSnackbar({
          ...snackbar,
          open: true,
          message: "Feestdag succesvol verwijderd",
        });
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const renderEventContent = (eventInfo) => {
    return (
      <>
        &nbsp;<i>{eventInfo.event.title}</i>
      </>
    );
  };

  const handleCloseSnackbar = () => {
    setSnackbar({ ...snackbar, open: false, message: "" });
  };

  return (
    <>
      {events !== null ? (
        <div className="demo-app">
          <div className="demo-app-main">
            <FullCalendar
              plugins={[
                bootstrap5Plugin,
                dayGridPlugin,
                timeGridPlugin,
                interactionPlugin,
              ]}
              headerToolbar={{
                left: "prev,next today",
                center: "title",
                right: "dayGridMonth,timeGridWeek,timeGridDay",
              }}
              locale={nlLocale}
              height={700}
              initialView="dayGridMonth"
              navLinks
              themeSystem="bootstrap5"
              dateClick={handleDateSelect}
              eventClick={handleEventClick}
              eventContent={renderEventContent}
              events={events}
              weekends
            />
          </div>
        </div>
      ) : (
        <CalendarSkeleton />
      )}
      <HolidayAddEditDialog
        open={openAddOrEditDialog}
        onClose={setOpenAddOrEditDialog}
        apiErrors={apiErrors}
        onAddOrEdit={handleAddOrEdit}
      />
      <HolidayDeleteDialog
        open={openDeleteDialog}
        onClose={setOpenDeleteDialog}
        eventInfo={eventInfo}
        onDelete={handleDelete}
      />
      <SuccessSnackbar
        open={snackbar.open}
        onClose={handleCloseSnackbar}
        message={snackbar.message}
      />
    </>
  );
}

function CalendarSkeleton() {
  return (
    <Grid container spacing={2} sx={{ marginTop: "0px" }}>
      <Grid item xs={1}>
        <Skeleton animation="wave" variant="rectangular" height={35} />
      </Grid>
      <Grid item xs={1}>
        <Skeleton animation="wave" variant="rectangular" height={35} />
      </Grid>
      <Grid item xs={1}>
        <Skeleton animation="wave" variant="rectangular" height={35} />
      </Grid>
      <Grid item xs={6}>
        <Skeleton animation="wave" variant="rectangular" height={35} />
      </Grid>
      <Grid item xs={1}>
        <Skeleton animation="wave" variant="rectangular" height={35} />
      </Grid>
      <Grid item xs={1}>
        <Skeleton animation="wave" variant="rectangular" height={35} />
      </Grid>
      <Grid item xs={1}>
        <Skeleton animation="wave" variant="rectangular" height={35} />
      </Grid>
      {[...Array(6)].map((e, i) => (
        <React.Fragment key={i}>
          <Grid item xs={1.714285714285714}>
            <Skeleton variant="rectangular" animation="wave" height={100} />
          </Grid>
          <Grid item xs={1.714285714285714}>
            <Skeleton variant="rectangular" animation="wave" height={100} />
          </Grid>
          <Grid item xs={1.714285714285714}>
            <Skeleton variant="rectangular" animation="wave" height={100} />
          </Grid>
          <Grid item xs={1.714285714285714}>
            <Skeleton variant="rectangular" animation="wave" height={100} />
          </Grid>
          <Grid item xs={1.714285714285714}>
            <Skeleton variant="rectangular" animation="wave" height={100} />
          </Grid>
          <Grid item xs={1.714285714285714}>
            <Skeleton variant="rectangular" animation="wave" height={100} />
          </Grid>
          <Grid item xs={1.714285714285714}>
            <Skeleton variant="rectangular" animation="wave" height={100} />
          </Grid>
        </React.Fragment>
      ))}
    </Grid>
  );
}

function HolidayAddEditDialog(props) {
  return (
    <Dialog
      open={props.open}
      onClose={() => props.onClose(false)}
      fullWidth
      maxWidth="sm"
    >
      <DialogTitle>Voeg feestdag toe</DialogTitle>
      <DialogContent>
        <HolidayForm
          apiErrors={props.apiErrors}
          onAddOrEdit={props.onAddOrEdit}
          onClose={props.onClose}
        />
      </DialogContent>
    </Dialog>
  );
}

function HolidayDeleteDialog(props) {
  return (
    <Dialog open={props.open} onClose={() => props.onClose(false)}>
      <DialogTitle sx={{ textAlign: "justify" }}>
        Weet je zeker dat je feestdag "
        {props.eventInfo && props.eventInfo.event.title}" op "
        {props.eventInfo && props.eventInfo.event.startStr}" wilt verwijderen?
      </DialogTitle>
      <DialogContent>
        <DialogContentText>
          Deze actie kan <strong>niet</strong> ongedaan gemaakt worden.
        </DialogContentText>
      </DialogContent>
      <DialogActions>
        <Button onClick={() => props.onClose(false)}>ANNULEREN</Button>
        <Button
          color="error"
          onClick={() => props.onDelete(props.eventInfo.event)}
        >
          VERWIJDEREN
        </Button>
      </DialogActions>
    </Dialog>
  );
}
