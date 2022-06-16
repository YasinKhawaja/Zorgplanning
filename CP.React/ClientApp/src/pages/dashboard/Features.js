import ArrowForwardIcon from "@mui/icons-material/ArrowForward";
import CelebrationIcon from "@mui/icons-material/Celebration";
import GroupsIcon from "@mui/icons-material/Groups";
import TableViewIcon from "@mui/icons-material/TableView";
import { Button } from "@mui/material";
import { NavLink } from "react-router-dom";
import "./Dashboard.css";

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
        Zorgplanner
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
            <NavLink to="/holidays" className="link">
              <Button variant="outlined" endIcon={<ArrowForwardIcon />}>
                Feestdagen
              </Button>
            </NavLink>
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
            <NavLink to="/teams" className="link">
              <Button variant="outlined" endIcon={<ArrowForwardIcon />}>
                Teams
              </Button>
            </NavLink>
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
            <NavLink to="/planning" className="link">
              <Button variant="outlined" endIcon={<ArrowForwardIcon />}>
                Planning
              </Button>
            </NavLink>
          </div>
        </div>
      </div>
    </div>
  );
}
