﻿ALTER TABLE [dbo].[Note] ADD CONSTRAINT [IX_Log_id] UNIQUE NONCLUSTERED  ([ID]) WITH (FILLFACTOR=1) ON [PRIMARY]

