# VR Experiment Analysis Summary
## Scope and design
- Analyzed 12 participants (P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P13). The questionnaire row `P01` was excluded as a test/pilot row.
- Participant mapping used: P1=EXAULE, P2=FONA, P3=Ange, P4=TOHA, P5=IBRAHIME, P6=MOUSSA, P7=EDWARD, P8=TONY, P9=YOUSSEF, P10=Zineb, P11=Clawde, P13=Susane.
- Working scene-condition mapping used for combined analysis: `chrono_scene 1`=Guided, `chrono_scene`=Autonomous, `chrono_scene 2`=Stress. This is inferred from the questionnaire/codebook naming and should be verified against the Unity build.
- Objective data include 36 retained rows: 3 scene records per participant. Questionnaire data include 36 analyzable session-condition records after excluding P01.
- Timestamp ties occurred in 0 objective rows; chronological order uses timestamp, then source file row as tie-break.
- 5 rows have `TotalTimeSeconds` differing from the sum of exported step times by more than 1 second. Total time is therefore treated as the primary timing endpoint.

## Main objective findings
- Chronological learning: mean total time changed from 101.1s (Run 1) to 65.6s (Run 2) and 67.5s (Run 3). Mean Run1->Run2 change was -33.4%.
- H1 test: Friedman chi-square=12.67, Kendall W=0.53, p=0.002. This is strong pilot evidence for a within-subject learning/familiarization effect.
- Error learning: mean false grabs changed from 5.7 (Run 1) to 3.0 (Run 2) and 2.2 (Run 3).
- H2 test: Friedman chi-square=2.04, Kendall W=0.09, p=0.360. This is directional/partial evidence rather than a confirmed global effect; false-grab logging should also be checked because several scene rows share identical values.
- By condition, mean total time was Guided 72.4s, Autonomous 78.6s, Stress 83.2s. Mean false grabs were Guided 2.9, Autonomous 2.7, Stress 5.3.

## Subjective questionnaire findings
- Learning/autonomy was near ceiling: Guided 4.33/5, Autonomous 4.90/5, Stress 4.96/5.
- Presence/realism was also high: Guided 6.30/7, Autonomous 6.62/7, Stress 6.60/7.
- Comfort symptoms stayed low: Guided 0.43/3, Autonomous 0.33/3, Stress 0.39/3.
- Acceptance was extremely high: Guided 4.67/5, Autonomous 4.89/5, Stress 5.00/5. This is useful for feasibility, but ceiling effects reduce discriminative power.

## Hypotheses
- H1 skill acquisition: supported as pilot evidence. Objective time decreases strongly from the first chronological run to later runs.
- H2 error reduction: partially supported. False grabs decrease after the first run and Run1->Run3 is significant, but the global three-run test is not significant and the error metric needs logging validation.
- H3 presence and accuracy: not proven. Participant-average Spearman rho between presence/realism and false grabs is -0.08, exact p=0.796. The presence scale has ceiling effects.
- H4 adaptability under unexpected events: promising but not proven. Stress condition is descriptively slower and more error-prone, while stress ratings remain low and guidance/adaptation scores remain high. A stronger claim needs event-severity logs or a clearer manipulation check.

## Pairwise chronological tests
| Metric | Comparison | Mean delta | Median delta | Exact p | Rank-biserial |
|---|---:|---:|---:|---:|---:|
| TotalTimeSeconds | Run 1 -> Run 2 | -35.49 | -38.54 | 0.002 | -0.92 |
| TotalTimeSeconds | Run 1 -> Run 3 | -33.53 | -27.72 | <0.001 | -1.00 |
| TotalTimeSeconds | Run 2 -> Run 3 | 1.97 | -0.66 | 0.677 | 0.15 |
| FalseGrabsTotal | Run 1 -> Run 2 | -2.67 | 0.00 | 0.664 | -0.18 |
| FalseGrabsTotal | Run 1 -> Run 3 | -3.42 | -1.50 | 0.102 | -0.62 |
| FalseGrabsTotal | Run 2 -> Run 3 | -0.75 | -0.50 | 0.266 | -0.47 |

## Diagram index
- [Randomized order matrix](01_randomized_session_order.png)
- [Total-time learning curve](02_chronological_total_time.png)
- [False-grab learning curve](02b_chronological_false_grabs.png)
- [Objective condition boxplots](03_condition_objective_boxplots.png)
- [Step-time heatmap](04_step_time_heatmap.png)
- [Subjective questionnaire composites](05_subjective_composite_scores.png)
- [Presence-error relation](06_presence_error_relation.png)
- [Hypothesis evidence matrix](07_hypothesis_evidence_matrix.png)

## Recommended doctoral-standard wording
The current dataset should be presented as a pilot within-subject validation of a VR industrial-training platform. It can support claims of feasibility, high user acceptance, low discomfort, and a measurable learning effect across repeated exposure. It should not yet be framed as definitive proof of all experimental hypotheses because the sample is small, the scene-condition mapping should be verified, the stress manipulation lacks an independent event-severity log, and subjective presence/acceptance scores show ceiling effects.
