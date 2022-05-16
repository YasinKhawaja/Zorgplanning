import ArrowForwardIcon from "@mui/icons-material/ArrowForward";
import CelebrationIcon from "@mui/icons-material/Celebration";
import GroupsIcon from "@mui/icons-material/Groups";
import TableViewIcon from "@mui/icons-material/TableView";
import { Button } from "@mui/material";
import React from "react";
import { Link } from "react-router-dom";

const useStyles = () => ({
  h2: { marginBottom: "12px" },
  p: {
    marginBottom: "24px",
    textAlign: "justify",
  },
});

export default function Features() {
  const classes = useStyles();

  return (
    <div className="container">
      <h2
        className="border-bottom text-center pb-4"
        style={{ marginBottom: "0px" }}
      >
        Zorgplanning
      </h2>
      <div
        className="row g-4 row-cols-1 row-cols-lg-3"
        style={{ marginTop: "48px", marginBottom: "24px" }}
      >
        <div className="col d-flex align-items-start">
          <div className="icon-square bg-light text-dark flex-shrink-0 me-3">
            <CelebrationIcon color="primary" fontSize="large" />
          </div>
          <div>
            <h2 style={classes.h2}>Feestdagen</h2>
            <p style={classes.p}>
              Beheer de feestdagen in een bepaalde maand met behulp van een
              kalender.
            </p>
            <Link to="/holidays">
              <Button variant="outlined" endIcon={<ArrowForwardIcon />}>
                Feestdagen
              </Button>
            </Link>
          </div>
        </div>
        <div className="col d-flex align-items-start">
          <div className="icon-square bg-light text-dark flex-shrink-0 me-3">
            <GroupsIcon color="primary" fontSize="large" />
          </div>
          <div>
            <h2 style={classes.h2}>Teams</h2>
            <p style={classes.p}>
              Maak teams aan, voeg zorgkundigen toe en beheer hun
              verlofplanning.
            </p>
            <Link to="/teams">
              <Button variant="outlined" endIcon={<ArrowForwardIcon />}>
                Teams
              </Button>
            </Link>
          </div>
        </div>
        <div className="col d-flex align-items-start">
          <div className="icon-square bg-light text-dark flex-shrink-0 me-3">
            <TableViewIcon color="primary" fontSize="large" />
          </div>
          <div>
            <h2 style={classes.h2}>Planning</h2>
            <p style={classes.p}>
              Genereer een maandplanning voor een bepaalde team en exporteer
              deze als <i>Excel</i>.
            </p>
            <Link to="/planning">
              <Button variant="outlined" endIcon={<ArrowForwardIcon />}>
                Planning
              </Button>
            </Link>
          </div>
        </div>
      </div>
    </div>
  );
}
