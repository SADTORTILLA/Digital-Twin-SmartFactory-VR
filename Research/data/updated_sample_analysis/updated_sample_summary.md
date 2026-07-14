# Updated Sample Analysis

- Analyzable participants: 12.
- Objective sessions: 36; questionnaire session blocks: 36.
- Age: 21.2 +/- 3.0 years (range 19-30).
- Gender: 2 female and 10 male.
- Program: 7 Industrial Engineering and 5 Computer Engineering.
- VR experience: 2 experienced and 10 first-time users.

## Condition balance by chronological run

| ChronologicalSession | Guided | Autonomous | Stress |
| --- | --- | --- | --- |
| 1 | 4 | 4 | 4 |
| 2 | 5 | 6 | 1 |
| 3 | 3 | 2 | 7 |

## Learning/autonomy condition effect

- Friedman chi-square=9.04, p=0.011, Kendall W=0.38.
| comparison | n_nonzero | mean_delta | median_delta | raw_p | rank_biserial | holm_p |
| --- | --- | --- | --- | --- | --- | --- |
| Guided vs Autonomous | 11 | 0.5694444444444443 | 0.25 | 0.0166015625 | 0.8181818181818182 | 0.033203125 |
| Guided vs Stress | 9 | 0.625 | 0.3333333333333335 | 0.00390625 | 1.0 | 0.01171875 |
| Autonomous vs Stress | 8 | 0.05555555555555566 | 0.08333333333333348 | 0.4375 | 0.3888888888888889 | 0.4375 |

## Exploratory subgroup caution

- Gender and VR-experience groups are 10:2 splits. Treat all comparisons as descriptive only.
- Program groups are 7:5, but the pilot was not powered for subgroup inference.
- Subgroup permutation tests are saved for audit and should not be promoted to confirmatory hypotheses.

## Data integrity

- 5 retained rows differ by more than one second between total time and summed step time.
- Total completion time remains the primary timing endpoint.