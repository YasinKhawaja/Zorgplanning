import React from "react";
import Header from "../../components/presentations/Header";
import Main from "../../components/presentations/Main";
import { areAllKeysPopulated } from "./planning-utils";
import PlanningWizard from "./PlanningWizard";

function PlanningIndex() {
  const [isMounted, setIsMounted] = React.useState(false);
  const [planningValues, setPlanningValues] = React.useState({});
  const [showTable, setShowTable] = React.useState(false);

  React.useEffect(() => {
    setIsMounted(true);
  }, []);

  React.useEffect(() => {
    if (isMounted) {
      if (areAllKeysPopulated(planningValues)) {
        setShowTable(true);
      }
    }
  }, [planningValues]);

  return (
    <React.Fragment>
      <Header />
      <Main>
        {showTable ? (
          <table className="tg">
            <thead>
              <tr>
                <th className="tg-0lax">{planningValues.teamId}</th>
                <th className="tg-0lax">{planningValues.year}</th>
                <th className="tg-0lax">{planningValues.month}</th>
                <th className="tg-0lax">a</th>
                <th className="tg-0lax">a</th>
                <th className="tg-0lax">a</th>
                <th className="tg-0lax">a</th>
                <th className="tg-0lax">a</th>
                <th className="tg-0lax">a</th>
                <th className="tg-0lax">a</th>
                <th className="tg-0lax">a</th>
                <th className="tg-0lax">a</th>
                <th className="tg-0lax">a</th>
                <th className="tg-0lax">a</th>
                <th className="tg-0lax">a</th>
                <th className="tg-0lax">a</th>
                <th className="tg-0lax">a</th>
                <th className="tg-0lax">a</th>
                <th className="tg-0lax">a</th>
                <th className="tg-0lax">a</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
              </tr>
              <tr>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
              </tr>
              <tr>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
              </tr>
              <tr>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
              </tr>
              <tr>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
              </tr>
              <tr>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
              </tr>
              <tr>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
              </tr>
              <tr>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
              </tr>
              <tr>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
                <td className="tg-0lax">a</td>
              </tr>
            </tbody>
          </table>
        ) : (
          <PlanningWizard onChangePlanningValues={setPlanningValues} />
        )}
      </Main>
    </React.Fragment>
  );
}

export default PlanningIndex;
