import FullCalendar from "@fullcalendar/react"; // MUST BE IMPORTED BEFORE PLUGINS
import bootstrap5Plugin from "@fullcalendar/bootstrap5";
import nlLocale from "@fullcalendar/core/locales/nl";
import dayGridPlugin from "@fullcalendar/daygrid";
import interactionPlugin from "@fullcalendar/interaction";
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
import EmployeeService from "../../services/EmployeeService";
import AbsenceForm from "./AbsenceForm";
import { createEventId } from "./event-utils";

export default function Calendar(props) {
  const [events, setEvents] = React.useState(null);
  const [openAddOrEditDialog, setOpenAddOrEditDialog] = React.useState(false);
  const [openDeleteDialog, setOpenDeleteDialog] = React.useState(false);
  const [selectedDay, setSelectedDay] = React.useState(null);
  const [eventInfo, setEventInfo] = React.useState(null);
  const [apiErrors, setApiErrors] = React.useState(null);

  React.useEffect(() => {
    fetchEvents();
  }, []);

  React.useEffect(() => {
    if (!openAddOrEditDialog) {
      setApiErrors(null);
    }
  }, [openAddOrEditDialog]);

  const fetchEvents = () => {
    EmployeeService.getAllAbsences(props.employee.id)
      .then((response) => {
        let absences = response.data.result;
        let events = [];
        absences.forEach((element) => {
          events.push({
            id: createEventId(),
            title: element.type,
            start: new Date(element.day),
            allDay: true,
            backgroundColor: getColor(element),
            borderColor: getColor(element),
          });
        });
        setEvents(events);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const getColor = (absence) => {
    let color = "";
    switch (absence.type) {
      case "Leave":
        color = "#228B22";
        break;
      case "Sickness":
        color = "#FF0000";
        break;
      case "WorkingTimeReduction":
        color = "#0000FF";
      default:
        break;
    }
    return color;
  };

  const handleDateSelect = (selectInfo) => {
    setSelectedDay(selectInfo);
    setOpenAddOrEditDialog(true);
  };

  const handleEventClick = (clickInfo) => {
    setEventInfo(clickInfo);
    setOpenDeleteDialog(true);
  };

  const handleDelete = (event) => {
    EmployeeService.removeAbsence(props.employee.id, event.startStr)
      .then(() => {
        fetchEvents();
        setOpenDeleteDialog(false);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const handleAddOrEdit = (values, resetFormFn) => {
    const absence = {
      ...values,
      employeeId: props.employee.id,
      day: selectedDay.dateStr,
    };
    const data = JSON.stringify(absence);
    EmployeeService.createAbsence(props.employee.id, data)
      .then((response) => {
        resetFormFn();
        setOpenAddOrEditDialog(false);
        fetchEvents();
      })
      .catch((error) => {
        setApiErrors(error.response.data.errors);
      });
  };

  const renderEventContent = (eventInfo) => {
    return (
      <>
        &nbsp;<i>{eventInfo.event.title}</i>
      </>
    );
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
      <AbsenceAddEditDialog
        open={openAddOrEditDialog}
        onClose={setOpenAddOrEditDialog}
        apiErrors={apiErrors}
        onAddOrEdit={handleAddOrEdit}
      />
      <AbsenceDeleteDialog
        open={openDeleteDialog}
        onClose={setOpenDeleteDialog}
        eventInfo={eventInfo}
        onDelete={handleDelete}
      />
    </>
  );
}

function CalendarSkeleton() {
  return (
    <Grid container spacing={2}>
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

function AbsenceAddEditDialog(props) {
  return (
    <Dialog
      open={props.open}
      onClose={() => props.onClose(false)}
      fullWidth
      maxWidth="sm"
    >
      <DialogTitle>Voeg afwezigheid toe</DialogTitle>
      <DialogContent>
        <AbsenceForm
          apiErrors={props.apiErrors}
          onAddOrEdit={props.onAddOrEdit}
          onClose={props.onClose}
        />
      </DialogContent>
    </Dialog>
  );
}

function AbsenceDeleteDialog(props) {
  return (
    <Dialog open={props.open} onClose={() => props.onClose(false)}>
      <DialogTitle>
        Weet je zeker dat je afwezigheid "
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
